using PICO.Properties;

namespace PICO
{
    partial class MainMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.logo = new System.Windows.Forms.PictureBox();
            this.labelCtrls = new System.Windows.Forms.Label();
            this.mainMenuTimer = new System.Windows.Forms.Timer(this.components);
            this.labelPressBtn = new System.Windows.Forms.Label();
            this.soundCtrl = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.BackgroundImage = global::PICO.Properties.Resources.logo_0;
            this.logo.Location = new System.Drawing.Point(145, 141);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(220, 116);
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // labelCtrls
            // 
            this.labelCtrls.AutoSize = true;
            this.labelCtrls.Font = new System.Drawing.Font("Early GameBoy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCtrls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelCtrls.Location = new System.Drawing.Point(12, 471);
            this.labelCtrls.Name = "labelCtrls";
            this.labelCtrls.Size = new System.Drawing.Size(204, 34);
            this.labelCtrls.TabIndex = 1;
            this.labelCtrls.Text = "Ctrls:\r\nzqsd, space, esc\r\n";
            // 
            // mainMenuTimer
            // 
            this.mainMenuTimer.Enabled = true;
            this.mainMenuTimer.Interval = 16;
            this.mainMenuTimer.Tick += new System.EventHandler(this.mainMenuTimer_Tick);
            // 
            // labelPressBtn
            // 
            this.labelPressBtn.AutoSize = true;
            this.labelPressBtn.Font = new System.Drawing.Font("Early GameBoy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPressBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelPressBtn.Location = new System.Drawing.Point(161, 320);
            this.labelPressBtn.Name = "labelPressBtn";
            this.labelPressBtn.Size = new System.Drawing.Size(193, 20);
            this.labelPressBtn.TabIndex = 2;
            this.labelPressBtn.Text = "Press button";
            // 
            // soundCtrl
            // 
            this.soundCtrl.Image = global::PICO.Properties.Resources.sound_up;
            this.soundCtrl.Location = new System.Drawing.Point(468, 468);
            this.soundCtrl.Name = "soundCtrl";
            this.soundCtrl.Size = new System.Drawing.Size(32, 32);
            this.soundCtrl.TabIndex = 3;
            this.soundCtrl.TabStop = false;
            this.soundCtrl.Click += new System.EventHandler(this.sound_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(512, 512);
            this.Controls.Add(this.soundCtrl);
            this.Controls.Add(this.labelPressBtn);
            this.Controls.Add(this.labelCtrls);
            this.Controls.Add(this.logo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Early GameBoy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(528, 551);
            this.MinimumSize = new System.Drawing.Size(528, 551);
            this.Name = "MainMenu";
            this.Text = "PICO-8";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox logo;
        private Label labelCtrls;
        private System.Windows.Forms.Timer mainMenuTimer;
        private Label labelPressBtn;
        private PictureBox sound;
        private PictureBox soundCtrl;
    }
}