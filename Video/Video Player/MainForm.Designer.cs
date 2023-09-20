using System.Drawing;
using System.Windows.Forms;

namespace SampleApp
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
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.fpsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.cstButton3 = new SampleApp.CustomButton.CstButton();
            this.cstButton2 = new SampleApp.CustomButton.CstButton();
            this.cstTriangleRight1 = new SampleApp.CustomButton.CstTriangleRight();
            this.cstTriangleLeft1 = new SampleApp.CustomButton.CstTriangleLeft();
            this.cstTriangleDown1 = new SampleApp.CustomButton.CstTriangleDown();
            this.cstTriangleUp1 = new SampleApp.CustomButton.CstTriangleUp();
            this.cstButton1 = new SampleApp.CustomButton.CstButton();
            this.label1 = new System.Windows.Forms.Label();
            this.videoSourcePlayer = new Accord.Controls.VideoSourcePlayer();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fpsLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 727);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 18, 0);
            this.statusStrip.Size = new System.Drawing.Size(651, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // fpsLabel
            // 
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(631, 16);
            this.fpsLabel.Spring = true;
            this.fpsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPanel.Controls.Add(this.cstButton3);
            this.mainPanel.Controls.Add(this.cstButton2);
            this.mainPanel.Controls.Add(this.cstTriangleRight1);
            this.mainPanel.Controls.Add(this.cstTriangleLeft1);
            this.mainPanel.Controls.Add(this.cstTriangleDown1);
            this.mainPanel.Controls.Add(this.cstTriangleUp1);
            this.mainPanel.Controls.Add(this.cstButton1);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.videoSourcePlayer);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(650, 749);
            this.mainPanel.TabIndex = 2;
            // 
            // cstButton3
            // 
            this.cstButton3.BackColor = System.Drawing.Color.MediumPurple;
            this.cstButton3.FlatAppearance.BorderSize = 0;
            this.cstButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cstButton3.ForeColor = System.Drawing.Color.White;
            this.cstButton3.Location = new System.Drawing.Point(503, 639);
            this.cstButton3.Name = "cstButton3";
            this.cstButton3.Size = new System.Drawing.Size(123, 42);
            this.cstButton3.TabIndex = 15;
            this.cstButton3.Text = "STOP CAMERA";
            this.cstButton3.UseVisualStyleBackColor = false;
            this.cstButton3.Click += new System.EventHandler(this.cstButton3_Click);
            // 
            // cstButton2
            // 
            this.cstButton2.BackColor = System.Drawing.Color.MediumPurple;
            this.cstButton2.FlatAppearance.BorderSize = 0;
            this.cstButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cstButton2.ForeColor = System.Drawing.Color.White;
            this.cstButton2.Location = new System.Drawing.Point(503, 509);
            this.cstButton2.Name = "cstButton2";
            this.cstButton2.Size = new System.Drawing.Size(123, 41);
            this.cstButton2.TabIndex = 14;
            this.cstButton2.Text = "SCREENSHOT";
            this.cstButton2.UseVisualStyleBackColor = false;
            this.cstButton2.Click += new System.EventHandler(this.cstButton2_Click);
            // 
            // cstTriangleRight1
            // 
            this.cstTriangleRight1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cstTriangleRight1.FlatAppearance.BorderSize = 0;
            this.cstTriangleRight1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cstTriangleRight1.ForeColor = System.Drawing.Color.White;
            this.cstTriangleRight1.Location = new System.Drawing.Point(205, 567);
            this.cstTriangleRight1.Name = "cstTriangleRight1";
            this.cstTriangleRight1.Size = new System.Drawing.Size(70, 100);
            this.cstTriangleRight1.TabIndex = 13;
            this.cstTriangleRight1.UseVisualStyleBackColor = false;
            // 
            // cstTriangleLeft1
            // 
            this.cstTriangleLeft1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cstTriangleLeft1.FlatAppearance.BorderSize = 0;
            this.cstTriangleLeft1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cstTriangleLeft1.ForeColor = System.Drawing.Color.White;
            this.cstTriangleLeft1.Location = new System.Drawing.Point(37, 567);
            this.cstTriangleLeft1.Name = "cstTriangleLeft1";
            this.cstTriangleLeft1.Size = new System.Drawing.Size(70, 100);
            this.cstTriangleLeft1.TabIndex = 12;
            this.cstTriangleLeft1.UseVisualStyleBackColor = false;
            // 
            // cstTriangleDown1
            // 
            this.cstTriangleDown1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cstTriangleDown1.FlatAppearance.BorderSize = 0;
            this.cstTriangleDown1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cstTriangleDown1.ForeColor = System.Drawing.Color.White;
            this.cstTriangleDown1.Location = new System.Drawing.Point(107, 672);
            this.cstTriangleDown1.Name = "cstTriangleDown1";
            this.cstTriangleDown1.Size = new System.Drawing.Size(100, 70);
            this.cstTriangleDown1.TabIndex = 11;
            this.cstTriangleDown1.UseVisualStyleBackColor = false;
            // 
            // cstTriangleUp1
            // 
            this.cstTriangleUp1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cstTriangleUp1.FlatAppearance.BorderSize = 0;
            this.cstTriangleUp1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cstTriangleUp1.ForeColor = System.Drawing.Color.White;
            this.cstTriangleUp1.Location = new System.Drawing.Point(107, 494);
            this.cstTriangleUp1.Name = "cstTriangleUp1";
            this.cstTriangleUp1.Size = new System.Drawing.Size(100, 70);
            this.cstTriangleUp1.TabIndex = 10;
            this.cstTriangleUp1.UseVisualStyleBackColor = false;
            // 
            // cstButton1
            // 
            this.cstButton1.BackColor = System.Drawing.Color.MediumPurple;
            this.cstButton1.FlatAppearance.BorderSize = 0;
            this.cstButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cstButton1.ForeColor = System.Drawing.Color.White;
            this.cstButton1.Location = new System.Drawing.Point(374, 639);
            this.cstButton1.Name = "cstButton1";
            this.cstButton1.Size = new System.Drawing.Size(123, 42);
            this.cstButton1.TabIndex = 9;
            this.cstButton1.Text = "START CAMERA";
            this.cstButton1.UseVisualStyleBackColor = false;
            this.cstButton1.Click += new System.EventHandler(this.cstButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(444, 609);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cam IP:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.videoSourcePlayer.ForeColor = System.Drawing.Color.White;
            this.videoSourcePlayer.Location = new System.Drawing.Point(3, 4);
            this.videoSourcePlayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(640, 480);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.VideoSource = null;
            this.videoSourcePlayer.NewFrameReceived += new Accord.Video.NewFrameEventHandler(this.videoSourcePlayer_NewFrame);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "AVI files (*.avi)|*.avi|All files (*.*)|*.*";
            this.openFileDialog.Title = "Opem movie";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(651, 749);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "CAMROBO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel mainPanel;
        private Accord.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel fpsLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private CustomButton.CstButton cstButton1;
        private CustomButton.CstTriangleDown cstTriangleDown1;
        private CustomButton.CstTriangleUp cstTriangleUp1;
        private CustomButton.CstTriangleRight cstTriangleRight1;
        private CustomButton.CstTriangleLeft cstTriangleLeft1;
        private CustomButton.CstButton cstButton2;
        private CustomButton.CstButton cstButton3;
    }
}

