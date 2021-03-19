namespace MysticLightUltimate
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.ImgRaw = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ImgProc = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NumBoxX = new System.Windows.Forms.NumericUpDown();
            this.NumBoxY = new System.Windows.Forms.NumericUpDown();
            this.NumBoxScale = new System.Windows.Forms.NumericUpDown();
            this.ComboRes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageMysticLight = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MysticLightOptions = new System.Windows.Forms.ListBox();
            this.pageLogitechG = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgRaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgProc)).BeginInit();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumBoxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBoxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBoxScale)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.pageMysticLight.SuspendLayout();
            this.pageLogitechG.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(242, 25);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(2);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(96, 26);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(242, 56);
            this.BtnStop.Margin = new System.Windows.Forms.Padding(2);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(96, 26);
            this.BtnStop.TabIndex = 1;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // ImgRaw
            // 
            this.ImgRaw.BackColor = System.Drawing.Color.Black;
            this.ImgRaw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImgRaw.Location = new System.Drawing.Point(9, 25);
            this.ImgRaw.Margin = new System.Windows.Forms.Padding(2);
            this.ImgRaw.Name = "ImgRaw";
            this.ImgRaw.Size = new System.Drawing.Size(216, 52);
            this.ImgRaw.TabIndex = 2;
            this.ImgRaw.TabStop = false;
            this.ImgRaw.Paint += new System.Windows.Forms.PaintEventHandler(this.ImgRaw_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(86, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Raw Capture";
            // 
            // ImgProc
            // 
            this.ImgProc.BackColor = System.Drawing.Color.Black;
            this.ImgProc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImgProc.Location = new System.Drawing.Point(9, 96);
            this.ImgProc.Margin = new System.Windows.Forms.Padding(2);
            this.ImgProc.Name = "ImgProc";
            this.ImgProc.Size = new System.Drawing.Size(216, 52);
            this.ImgProc.TabIndex = 4;
            this.ImgProc.TabStop = false;
            this.ImgProc.Paint += new System.Windows.Forms.PaintEventHandler(this.ImgProc_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(71, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Processed Capture";
            // 
            // StatusStrip
            // 
            this.StatusStrip.AutoSize = false;
            this.StatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 284);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.StatusStrip.Size = new System.Drawing.Size(348, 26);
            this.StatusStrip.TabIndex = 6;
            this.StatusStrip.Text = "Status";
            // 
            // StatusLabel
            // 
            this.StatusLabel.ActiveLinkColor = System.Drawing.Color.WhiteSmoke;
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.StatusLabel.LinkColor = System.Drawing.Color.WhiteSmoke;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(42, 21);
            this.StatusLabel.Text = "Ready.";
            this.StatusLabel.VisitedLinkColor = System.Drawing.Color.WhiteSmoke;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(235, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(232, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(212, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Scale";
            // 
            // NumBoxX
            // 
            this.NumBoxX.Location = new System.Drawing.Point(249, 20);
            this.NumBoxX.Margin = new System.Windows.Forms.Padding(2);
            this.NumBoxX.Maximum = new decimal(new int[] {
            7680,
            0,
            0,
            0});
            this.NumBoxX.Name = "NumBoxX";
            this.NumBoxX.Size = new System.Drawing.Size(75, 20);
            this.NumBoxX.TabIndex = 17;
            this.NumBoxX.ValueChanged += new System.EventHandler(this.NumBoxX_ValueChanged);
            // 
            // NumBoxY
            // 
            this.NumBoxY.Location = new System.Drawing.Point(249, 42);
            this.NumBoxY.Margin = new System.Windows.Forms.Padding(2);
            this.NumBoxY.Maximum = new decimal(new int[] {
            4320,
            0,
            0,
            0});
            this.NumBoxY.Name = "NumBoxY";
            this.NumBoxY.Size = new System.Drawing.Size(75, 20);
            this.NumBoxY.TabIndex = 18;
            this.NumBoxY.ValueChanged += new System.EventHandler(this.NumBoxY_ValueChanged);
            // 
            // NumBoxScale
            // 
            this.NumBoxScale.Location = new System.Drawing.Point(249, 65);
            this.NumBoxScale.Margin = new System.Windows.Forms.Padding(2);
            this.NumBoxScale.Maximum = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.NumBoxScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumBoxScale.Name = "NumBoxScale";
            this.NumBoxScale.Size = new System.Drawing.Size(75, 20);
            this.NumBoxScale.TabIndex = 19;
            this.NumBoxScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumBoxScale.ValueChanged += new System.EventHandler(this.NumBoxScale_ValueChanged);
            // 
            // ComboRes
            // 
            this.ComboRes.FormattingEnabled = true;
            this.ComboRes.Items.AddRange(new object[] {
            "720",
            "1080",
            "1440",
            "2160"});
            this.ComboRes.Location = new System.Drawing.Point(242, 119);
            this.ComboRes.Margin = new System.Windows.Forms.Padding(2);
            this.ComboRes.Name = "ComboRes";
            this.ComboRes.Size = new System.Drawing.Size(97, 21);
            this.ComboRes.TabIndex = 20;
            this.ComboRes.TextChanged += new System.EventHandler(this.ComboRes_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(243, 102);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Screen Resolution";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.NumBoxScale);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.NumBoxY);
            this.groupBox1.Controls.Add(this.NumBoxX);
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(9, 155);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(328, 115);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageMysticLight);
            this.tabControl.Controls.Add(this.pageLogitechG);
            this.tabControl.Location = new System.Drawing.Point(4, 15);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(187, 93);
            this.tabControl.TabIndex = 23;
            // 
            // pageMysticLight
            // 
            this.pageMysticLight.BackColor = System.Drawing.Color.Transparent;
            this.pageMysticLight.Controls.Add(this.textBox1);
            this.pageMysticLight.Controls.Add(this.label7);
            this.pageMysticLight.Controls.Add(this.MysticLightOptions);
            this.pageMysticLight.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pageMysticLight.Location = new System.Drawing.Point(4, 22);
            this.pageMysticLight.Margin = new System.Windows.Forms.Padding(2);
            this.pageMysticLight.Name = "pageMysticLight";
            this.pageMysticLight.Padding = new System.Windows.Forms.Padding(2);
            this.pageMysticLight.Size = new System.Drawing.Size(179, 67);
            this.pageMysticLight.TabIndex = 0;
            this.pageMysticLight.Text = "Mystic Light";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(109, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Hex Color";
            // 
            // MysticLightOptions
            // 
            this.MysticLightOptions.FormattingEnabled = true;
            this.MysticLightOptions.Items.AddRange(new object[] {
            "Single Color",
            "Random Flash"});
            this.MysticLightOptions.Location = new System.Drawing.Point(0, 2);
            this.MysticLightOptions.Margin = new System.Windows.Forms.Padding(2);
            this.MysticLightOptions.Name = "MysticLightOptions";
            this.MysticLightOptions.Size = new System.Drawing.Size(88, 69);
            this.MysticLightOptions.TabIndex = 0;
            this.MysticLightOptions.SelectedIndexChanged += new System.EventHandler(this.MysticLightOptions_SelectedIndexChanged);
            // 
            // pageLogitechG
            // 
            this.pageLogitechG.BackColor = System.Drawing.Color.Transparent;
            this.pageLogitechG.Controls.Add(this.label8);
            this.pageLogitechG.Location = new System.Drawing.Point(4, 22);
            this.pageLogitechG.Margin = new System.Windows.Forms.Padding(2);
            this.pageLogitechG.Name = "pageLogitechG";
            this.pageLogitechG.Padding = new System.Windows.Forms.Padding(2);
            this.pageLogitechG.Size = new System.Drawing.Size(179, 67);
            this.pageLogitechG.TabIndex = 1;
            this.pageLogitechG.Text = "Logitech";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(4, 2);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Coming Soon";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(199, 90);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Only on MouseDown";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(348, 310);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ComboRes);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ImgProc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImgRaw);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(364, 349);
            this.MinimumSize = new System.Drawing.Size(364, 349);
            this.Name = "MainForm";
            this.Text = "Mystic Light - R6 Edition";
            ((System.ComponentModel.ISupportInitialize)(this.ImgRaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgProc)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumBoxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBoxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBoxScale)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.pageMysticLight.ResumeLayout(false);
            this.pageMysticLight.PerformLayout();
            this.pageLogitechG.ResumeLayout(false);
            this.pageLogitechG.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.PictureBox ImgRaw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ImgProc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NumBoxX;
        private System.Windows.Forms.NumericUpDown NumBoxY;
        private System.Windows.Forms.NumericUpDown NumBoxScale;
        private System.Windows.Forms.ComboBox ComboRes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pageMysticLight;
        private System.Windows.Forms.TabPage pageLogitechG;
        private System.Windows.Forms.ListBox MysticLightOptions;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

