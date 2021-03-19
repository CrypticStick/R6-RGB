using MSIRGB;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace MysticLightUltimate
{
    public class MysticLightSDK
    {
        private static Lighting light;
        private static bool Initialized = false;
        private static bool Available = false;

        public static bool Init(bool silent = true)
        {
            if (!Initialized)
            {
                CheckForRunningMSIApps();
                TryInitializeDll(false, silent);

                if (Initialized)
                {
                    //Disable flashing & breathing features
                    light.SetStepDuration(0);
                    light.SetFlashingSpeed(Lighting.FlashingSpeed.Disabled);
                    light.SetBreathingModeEnabled(false);
                    light.SetLedEnabled(true);
                }
            }
            return Initialized;
        }

        public static void Shutdown()
        {
            if (Initialized)
            {
                light.Dispose();
                Initialized = false;
            }
        }

        public static bool IsAvailable(bool check = false)
        {
            if (check)
            {
                Available = Init();
                Shutdown();
            }
            return Available;
        }

        public static bool Ready()
        {
            return Initialized;
        }

        private static void CheckForRunningMSIApps()
        {
            string assemblyTitle = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute), false))?.Title;

            Process[] runningMSIProcesses = Process.GetProcessesByName("LEDKeeper");

            if (runningMSIProcesses.Count() > 0)
            {
                switch (MessageBox.Show("MSIRGB detected that an MSI application that could potentially interfere is running. " +
                    "This application is likely either MSI Mystic Light or MSI Gaming App. " + Environment.NewLine + Environment.NewLine +
                    "In order to start MSIRGB, you must stop this application." + Environment.NewLine + Environment.NewLine +
                    "Please make sure that neither of these applications are running at any time simultaneously with MSIRGB. " + "" +
                    "If MSIRGB is set to autostart a script on Windows startup, please make sure neither of these MSI applications are autostarted as well.",
                    assemblyTitle,
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Warning))
                {
                    case MessageBoxResult.OK:

                        break;

                    case MessageBoxResult.Cancel:
                        Application.Current.Shutdown();
                        break;
                }
            }
        }

        private static void TryInitializeDll(bool ignoreMbCheck = false, bool silent = true)
        {
            string assemblyTitle = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute), false))?.Title;

            try
            {
                light = new Lighting(ignoreMbCheck);
                Initialized = true;
            }
            catch (Lighting.Exception exc)
            {
                if (!silent)
                {
                    if (exc.GetErrorCode() == Lighting.ErrorCode.MotherboardModelNotSupported)
                    {
                        if (MessageBox.Show("Your motherboard is not on the list of supported motherboards. " +
                                            "Attempting to use this program may cause irreversible damage to your hardware and/or personal data. " +
                                            "Are you sure you want to continue?",
                                            assemblyTitle,
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            TryInitializeDll(true);
                            return;
                        }
                    }
                    else if (exc.GetErrorCode() == Lighting.ErrorCode.MotherboardVendorNotSupported)
                    {
                        MessageBox.Show("Your motherboard's vendor was not detected to be MSI. MSIRGB only supports MSI motherboards. " +
                            "To avoid damage to your hardware, MSIRGB will shutdown. " + Environment.NewLine + Environment.NewLine +
                            "If your motherboard's vendor is MSI, " + "" +
                            "please report this problem on the issue tracker at: https://github.com/ixjf/MSIRGB",
                            assemblyTitle,
                            MessageBoxButton.OK,
                            MessageBoxImage.Stop
                            );
                    }
                    else if (exc.GetErrorCode() == Lighting.ErrorCode.DriverLoadFailed)
                    {
                        MessageBox.Show("Failed to load driver. This could be either due to some program interfering with MSIRGB's driver, " +
                                        "or it could be a bug. Please report this on the issue tracker at: https://github.com/ixjf/MSIRGB",
                                        assemblyTitle,
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error
                                        );
                    }
                    else if (exc.GetErrorCode() == Lighting.ErrorCode.LoadFailed)
                    {
                        MessageBox.Show("Failed to load. Please report this on the issue tracker at: https://github.com/ixjf/MSIRGB",
                                        assemblyTitle,
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error
                                        );
                    }
                } 
                else
                {
                    //silently fails
                }
                //Application.Current.Shutdown();
            }
        }

        //added lock to avoid multiple threads mixing colors
        static object LEDLock = new object();
        public static void setLEDs(Color color)
        {
            color.R /= 0x11; // Colour must be passed with 12-bit depth
            color.G /= 0x11;
            color.B /= 0x11;

            lock (LEDLock) {
                light.BatchBegin();
                foreach (byte i in Enumerable.Range(1, 8))
                {
                    light.SetColour(i, color);
                }
                light.BatchEnd();
            }
        }

    }
}
