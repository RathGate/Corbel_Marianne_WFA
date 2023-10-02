namespace PICO
{
    partial class TitleMenu
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
            this.labelPressBtn = new System.Windows.Forms.Label();
            this.labelCtrls = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.soundCtrl = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTimer
            // 
            this.mainTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // labelPressBtn
            // 
            this.labelPressBtn.Font = new System.Drawing.Font("Early GameBoy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPressBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelPressBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPressBtn.Location = new System.Drawing.Point(145, 321);
            this.labelPressBtn.Name = "labelPressBtn";
            this.labelPressBtn.Size = new System.Drawing.Size(220, 20);
            this.labelPressBtn.TabIndex = 6;
            this.labelPressBtn.Text = "Press space";
            this.labelPressBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCtrls
            // 
            this.labelCtrls.AutoSize = true;
            this.labelCtrls.Font = new System.Drawing.Font("Early GameBoy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCtrls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.labelCtrls.Location = new System.Drawing.Point(12, 472);
            this.labelCtrls.Name = "labelCtrls";
            this.labelCtrls.Size = new System.Drawing.Size(273, 34);
            this.labelCtrls.TabIndex = 5;
            this.labelCtrls.Text = "Ctrls:\r\nzqsd, space, esc/enter";
            // 
            // logo
            // 
            this.logo.BackgroundImage = global::PICO.Properties.Resources.logo_0;
            this.logo.Location = new System.Drawing.Point(145, 142);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(220, 116);
            this.logo.TabIndex = 4;
            this.logo.TabStop = false;
            // 
            // soundCtrl
            // 
            this.soundCtrl.Image = global::PICO.Properties.Resources.sound_up;
            this.soundCtrl.Location = new System.Drawing.Point(469, 472);
            this.soundCtrl.Name = "soundCtrl";
            this.soundCtrl.Size = new System.Drawing.Size(32, 32);
            this.soundCtrl.TabIndex = 7;
            this.soundCtrl.TabStop = false;
            this.soundCtrl.Visible = false;
            this.soundCtrl.Click += new System.EventHandler(this.Sound_Click);
            // 
            // TitleMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 512);
            this.Controls.Add(this.soundCtrl);
            this.Controls.Add(this.labelPressBtn);
            this.Controls.Add(this.labelCtrls);
            this.Controls.Add(this.logo);
            this.Name = "TitleMenu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelPressBtn;
        private Label labelCtrls;
        private PictureBox logo;
        private PictureBox soundCtrl;
    }
}