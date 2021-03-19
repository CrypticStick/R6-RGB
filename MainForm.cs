using Gma.System.MouseKeyHook;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LedCSharp;

namespace MysticLightUltimate
{
    public partial class MainForm : Form
    {
        private Bitmap bmpRaw;
        private Bitmap bmpProc;
        private Rectangle bounds;

        private const int FIRERATE_MS = 4;
        private const float RATIO = 9 / 2f;
        private const int REQ_INTENSITY = 240;
        private const float REQ_PCT_CHANGE = 0.01f;

        private const float REF_RES = 1440f;
        private const float REF_X = 2272f;
        private const float REF_Y = 1288f;
        private const float REF_SCALE = 32f;

        private BackgroundWorker mainLoop = new BackgroundWorker();
        bool canFlash = true;
        bool closePending = false;
        public MainForm()
        {
            InitializeComponent();

            //check which devices are available

            if (!MysticLightSDK.IsAvailable(true))
            {
                tabControl.TabPages.RemoveByKey("pageMysticLight");
            }

            if (!LogitechGSDK.IsAvailable(true))
            {
                tabControl.TabPages.RemoveByKey("pageLogitechG");
            }

            //preparing images

            bmpRaw = new Bitmap((int)Math.Round((int)NumBoxScale.Value * RATIO), (int)NumBoxScale.Value, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bmpProc = new Bitmap((int)Math.Round((int)NumBoxScale.Value * RATIO), (int)NumBoxScale.Value, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);

            //preparing background thread for image processing

            mainLoop.WorkerSupportsCancellation = true;
            mainLoop.DoWork += new DoWorkEventHandler(MainLoop);
            mainLoop.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MainLoopCompleted);

            //preparing necessary hooks

            Hook.GlobalEvents().MouseDown += async (sender, e) =>
            {
                Console.WriteLine($"Mouse {e.Button} Down");
            };
        }

        //returns true if bmpProc changes beyond threshold
        private bool processBmp()
        {
            int whiteAdded = 0;
            int blackAdded = 0;

            unsafe
            {
                BitmapData bmpRawDat = bmpRaw.LockBits(new Rectangle(0, 0, bmpRaw.Width, bmpRaw.Height), ImageLockMode.ReadOnly, bmpRaw.PixelFormat);
                BitmapData bmpProcDat = bmpProc.LockBits(new Rectangle(0, 0, bmpProc.Width, bmpProc.Height), ImageLockMode.ReadWrite, bmpProc.PixelFormat);

                byte* PtrRawFirstPixel = (byte*)bmpRawDat.Scan0;
                byte* PtrProcFirstPixel = (byte*)bmpProcDat.Scan0;

                Parallel.ForEach<int, Tuple<int, int>>(Enumerable.Range(0, bmpRawDat.Height),
                                     () => new Tuple<int, int>(0, 0),
                                     (y, loop, changeVal) =>
                                     {
                                         byte* rawCurrentLine = PtrRawFirstPixel + (y * bmpRawDat.Stride);
                                         byte* procCurrentLine = PtrProcFirstPixel + (y * bmpProcDat.Stride);
                                         for (int x = 0; x < bmpRawDat.Width; x++)
                                         {
                                             //currentLine[x] == blue, ...[x+1] == green, ...[x+2] = red
                                             if (rawCurrentLine[(x * 3) + 2] < REQ_INTENSITY)
                                             {
                                                 //divide x by 8 (x >> 3) to get current byte
                                                 //AND byte with byte containing bit at target index
                                                 //if result is not zero, bit is 1
                                                 if ((procCurrentLine[x >> 3] & (byte)(0x80 >> (x & 0x7))) != 0)
                                                     changeVal = new Tuple<int, int>(changeVal.Item1 + 1, changeVal.Item2);
                                                 procCurrentLine[x >> 3] &= (byte)~(0x80 >> (x & 0x7));
                                             }
                                             else
                                             {
                                                 if ((procCurrentLine[x >> 3] & (byte)(0x80 >> (x & 0x7))) == 0)
                                                     changeVal = new Tuple<int, int>(changeVal.Item1, changeVal.Item2 + 1);
                                                 procCurrentLine[x >> 3] |= (byte)(0x80 >> (x & 0x7));
                                             }
                                         }
                                         return changeVal;
                                     },
                                     (changeVal) => {
                                         Interlocked.Add(ref whiteAdded, changeVal.Item1);
                                         Interlocked.Add(ref blackAdded, changeVal.Item2);
                                     }
                                     );

                bmpRaw.UnlockBits(bmpRawDat);
                bmpProc.UnlockBits(bmpProcDat);
            }
            return  whiteAdded > 0 && 
                    blackAdded > 0 && 
                    (whiteAdded + blackAdded > (bmpRaw.Width * bmpRaw.Height) * REQ_PCT_CHANGE);
        }

        private void screenToBMP()
        {
            Graphics.FromImage(bmpRaw).CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
        }

        private void MainLoop(object sender, DoWorkEventArgs e)
        {
            while (!(sender as BackgroundWorker).CancellationPending)
            {
                screenToBMP();
                if (processBmp())
                {
                    Invoke(new Action(() =>
                    {
                        StatusStrip.BackColor = System.Drawing.Color.FromArgb(255, 180, 0, 0);
                        StatusLabel.Text = (int.Parse(StatusLabel.Text) + 1).ToString();
                    }));
                    UpdateLights();
                    Invoke(new Action(() => StatusStrip.BackColor = System.Drawing.Color.FromArgb(255, 48, 48, 48)));
                }
                Invoke(new Action(() =>
                {
                    ImgRaw.Refresh();
                    ImgProc.Refresh();
                }));
            }
        }

        private void UpdateLights()
        {
            Random rnd = new Random();
            int r, g, b;
            HsvToRgb(rnd.Next(0, 360), 1, 1, out r, out g, out b);

            //START OF EFFECT
            if (MysticLightSDK.Ready())
            {
                MysticLightSDK.setLEDs(System.Windows.Media.Color.FromRgb((byte)r, (byte)g, (byte)b));
            }

            if (LogitechGSDK.Ready())
            {
                LogitechGSDK.LogiLedSetLighting(r * 100 / 255, g * 100 / 255, b * 100 / 255);
            }

            Thread.Sleep(FIRERATE_MS);

            //END OF EFFECT
            LightsOff();
        }

        private void LightsOff()
        {
            if (MysticLightSDK.Ready())
            {
                MysticLightSDK.setLEDs(System.Windows.Media.Color.FromRgb(0, 0, 0));
            }

            if (LogitechGSDK.Ready())
            {
                //LogitechGSDK.LogiLedSetLighting(0, 0, 0);
            }
        }

        private void MainLoopCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (closePending) Close();
            closePending = false;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!mainLoop.IsBusy)
            {
                //code actually works with these enabled, but I'm being safe
                NumBoxX.Enabled = false;
                NumBoxY.Enabled = false;
                NumBoxScale.Enabled = false;
                ComboRes.Enabled = false;

                if (MysticLightSDK.IsAvailable())
                {
                    MysticLightSDK.Init(false);
                }

                if (LogitechGSDK.IsAvailable())
                {
                    LogitechGSDK.Init(false);
                }

                LightsOff();

                mainLoop.RunWorkerAsync();
                StatusLabel.Text = "0";
                //StatusLabel.Text = "Scanning...";
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (mainLoop.IsBusy)
            {
                NumBoxX.Enabled = true;
                NumBoxY.Enabled = true;
                NumBoxScale.Enabled = true;
                ComboRes.Enabled = true;

                if (MysticLightSDK.Ready())
                {
                    MysticLightSDK.Shutdown();
                }

                if (LogitechGSDK.Ready())
                {
                    LogitechGSDK.Shutdown();
                }

                mainLoop.CancelAsync();
                StatusLabel.Text = "Stopped.";
            }
            LightsOff();
        }

        private void ImgRaw_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmpRaw, new Rectangle(0, 0, ImgRaw.Width, ImgRaw.Height), new Rectangle(0, 0, bmpRaw.Width, bmpRaw.Height),  GraphicsUnit.Pixel);
        }

        private void ImgProc_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmpProc, new Rectangle(0, 0, ImgProc.Width, ImgProc.Height), new Rectangle(0, 0, bmpProc.Width, bmpProc.Height), GraphicsUnit.Pixel);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (mainLoop.IsBusy)
            {
                closePending = true;
                mainLoop.CancelAsync();
                e.Cancel = true;
                Hide();
                return;
            }

            MysticLightSDK.Shutdown();
            LogitechGSDK.Shutdown();

            base.OnFormClosing(e);
        }

        private void RefreshDimensions()
        {
            bmpRaw = new Bitmap((int)Math.Round((int)NumBoxScale.Value * RATIO), (int)NumBoxScale.Value, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bmpProc = new Bitmap((int)Math.Round((int)NumBoxScale.Value * RATIO), (int)NumBoxScale.Value, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            bounds = new Rectangle((int)NumBoxX.Value, (int)NumBoxY.Value, (int)Math.Round((int)NumBoxScale.Value * RATIO), (int)NumBoxScale.Value);
            screenToBMP();
            ImgRaw.Refresh();
            ImgProc.Refresh();
        }
        private void NumBoxX_ValueChanged(object sender, EventArgs e)
        {
            RefreshDimensions();
        }

        private void NumBoxY_ValueChanged(object sender, EventArgs e)
        {
            RefreshDimensions();
        }

        private void NumBoxScale_ValueChanged(object sender, EventArgs e)
        {
            RefreshDimensions();
        }

        private void ComboRes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int res = int.Parse((sender as ComboBox).Text);
                double scaleFactor = res / REF_RES;
                NumBoxX.Value = (decimal)(REF_X * scaleFactor);
                NumBoxY.Value = (decimal)(REF_Y * scaleFactor);
                NumBoxScale.Value = (decimal)(REF_SCALE * scaleFactor);
            }
            catch
            {
                //bruh
            }
        }

        //a color conversion function I took from StackOverflow, yeehaw
        void HsvToRgb(double h, double S, double V, out int r, out int g, out int b)
        {
            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            r = Clamp((int)(R * 255.0));
            g = Clamp((int)(G * 255.0));
            b = Clamp((int)(B * 255.0));
        }

        /// <summary>
        /// Clamp a value to 0-255
        /// </summary>
        int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }

        private void MysticLightOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
