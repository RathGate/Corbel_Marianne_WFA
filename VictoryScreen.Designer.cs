namespace PICO
{
    partial class VictoryScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VictoryScreen));
            this.pausePanel = new System.Windows.Forms.Panel();
            this.pictureBox74 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.option0 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.option1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.finalDeathCount = new System.Windows.Forms.Label();
            this.deathIcon = new System.Windows.Forms.PictureBox();
            this.finalTime = new System.Windows.Forms.Label();
            this.berryIcon = new System.Windows.Forms.PictureBox();
            this.clockIcon = new System.Windows.Forms.PictureBox();
            this.finalBerryCount = new System.Windows.Forms.Label();
            this.pausa = new System.Windows.Forms.Label();
            this.soundCtrl = new System.Windows.Forms.PictureBox();
            this.pausePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox74)).BeginInit();
            this.panel1.SuspendLayout();
            this.option0.SuspendLayout();
            this.option1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deathIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.berryIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clockIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTimer
            // 
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // pausePanel
            // 
            this.pausePanel.Controls.Add(this.pictureBox74);
            this.pausePanel.Controls.Add(this.panel1);
            this.pausePanel.Controls.Add(this.groupBox2);
            this.pausePanel.Controls.Add(this.pausa);
            this.pausePanel.Controls.Add(this.soundCtrl);
            this.pausePanel.Location = new System.Drawing.Point(0, 0);
            this.pausePanel.MaximumSize = new System.Drawing.Size(512, 512);
            this.pausePanel.MinimumSize = new System.Drawing.Size(512, 512);
            this.pausePanel.Name = "pausePanel";
            this.pausePanel.Size = new System.Drawing.Size(512, 512);
            this.pausePanel.TabIndex = 87;
            // 
            // pictureBox74
            // 
            this.pictureBox74.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox74.Image = global::PICO.Properties.Resources.golden;
            this.pictureBox74.Location = new System.Drawing.Point(405, 79);
            this.pictureBox74.MinimumSize = new System.Drawing.Size(32, 32);
            this.pictureBox74.Name = "pictureBox74";
            this.pictureBox74.Size = new System.Drawing.Size(32, 40);
            this.pictureBox74.TabIndex = 230;
            this.pictureBox74.TabStop = false;
            this.pictureBox74.Tag = "golden";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.option0);
            this.panel1.Controls.Add(this.option1);
            this.panel1.Location = new System.Drawing.Point(109, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 123);
            this.panel1.TabIndex = 88;
            // 
            // option0
            // 
            this.option0.Controls.Add(this.label4);
            this.option0.Location = new System.Drawing.Point(1, 23);
            this.option0.Name = "option0";
            this.option0.Size = new System.Drawing.Size(318, 32);
            this.option0.TabIndex = 87;
            this.option0.Tag = "pauseOption";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Early GameBoy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(32, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "reset cartridge";
            // 
            // option1
            // 
            this.option1.Controls.Add(this.label5);
            this.option1.Location = new System.Drawing.Point(1, 65);
            this.option1.Name = "option1";
            this.option1.Size = new System.Drawing.Size(318, 34);
            this.option1.TabIndex = 88;
            this.option1.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Early GameBoy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.label5.Location = new System.Drawing.Point(32, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "quit game";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.finalDeathCount);
            this.groupBox2.Controls.Add(this.deathIcon);
            this.groupBox2.Controls.Add(this.finalTime);
            this.groupBox2.Controls.Add(this.berryIcon);
            this.groupBox2.Controls.Add(this.clockIcon);
            this.groupBox2.Controls.Add(this.finalBerryCount);
            this.groupBox2.Location = new System.Drawing.Point(129, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 192);
            this.groupBox2.TabIndex = 87;
            this.groupBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PICO.Properties.Resources.maddy_11;
            this.pictureBox1.Location = new System.Drawing.Point(218, 158);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 231;
            this.pictureBox1.TabStop = false;
            // 
            // finalDeathCount
            // 
            this.finalDeathCount.AutoSize = true;
            this.finalDeathCount.Font = new System.Drawing.Font("Early GameBoy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.finalDeathCount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.finalDeathCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.finalDeathCount.Location = new System.Drawing.Point(66, 138);
            this.finalDeathCount.Margin = new System.Windows.Forms.Padding(0);
            this.finalDeathCount.Name = "finalDeathCount";
            this.finalDeathCount.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.finalDeathCount.Size = new System.Drawing.Size(65, 30);
            this.finalDeathCount.TabIndex = 88;
            this.finalDeathCount.Text = "x 0";
            this.finalDeathCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deathIcon
            // 
            this.deathIcon.BackgroundImage = global::PICO.Properties.Resources.skullIcon;
            this.deathIcon.Location = new System.Drawing.Point(31, 136);
            this.deathIcon.Name = "deathIcon";
            this.deathIcon.Size = new System.Drawing.Size(32, 32);
            this.deathIcon.TabIndex = 89;
            this.deathIcon.TabStop = false;
            // 
            // finalTime
            // 
            this.finalTime.AutoSize = true;
            this.finalTime.Font = new System.Drawing.Font("Early GameBoy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.finalTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.finalTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.finalTime.Location = new System.Drawing.Point(66, 89);
            this.finalTime.Margin = new System.Windows.Forms.Padding(0);
            this.finalTime.Name = "finalTime";
            this.finalTime.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.finalTime.Size = new System.Drawing.Size(169, 30);
            this.finalTime.TabIndex = 86;
            this.finalTime.Text = "00:00:00";
            this.finalTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // berryIcon
            // 
            this.berryIcon.BackgroundImage = global::PICO.Properties.Resources.berryIcon;
            this.berryIcon.Location = new System.Drawing.Point(31, 42);
            this.berryIcon.Name = "berryIcon";
            this.berryIcon.Size = new System.Drawing.Size(32, 32);
            this.berryIcon.TabIndex = 85;
            this.berryIcon.TabStop = false;
            // 
            // clockIcon
            // 
            this.clockIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("clockIcon.BackgroundImage")));
            this.clockIcon.Location = new System.Drawing.Point(31, 89);
            this.clockIcon.Name = "clockIcon";
            this.clockIcon.Size = new System.Drawing.Size(32, 32);
            this.clockIcon.TabIndex = 87;
            this.clockIcon.TabStop = false;
            // 
            // finalBerryCount
            // 
            this.finalBerryCount.AutoSize = true;
            this.finalBerryCount.Font = new System.Drawing.Font("Early GameBoy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.finalBerryCount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.finalBerryCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.finalBerryCount.Location = new System.Drawing.Point(66, 42);
            this.finalBerryCount.Margin = new System.Windows.Forms.Padding(0);
            this.finalBerryCount.Name = "finalBerryCount";
            this.finalBerryCount.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.finalBerryCount.Size = new System.Drawing.Size(65, 30);
            this.finalBerryCount.TabIndex = 84;
            this.finalBerryCount.Text = "x 0";
            this.finalBerryCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pausa
            // 
            this.pausa.AutoSize = true;
            this.pausa.Font = new System.Drawing.Font("Early GameBoy", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pausa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.pausa.Location = new System.Drawing.Point(83, 76);
            this.pausa.Name = "pausa";
            this.pausa.Size = new System.Drawing.Size(316, 47);
            this.pausa.TabIndex = 80;
            this.pausa.Text = "Victory!";
            // 
            // soundCtrl
            // 
            this.soundCtrl.Image = global::PICO.Properties.Resources.sound_up;
            this.soundCtrl.Location = new System.Drawing.Point(469, 472);
            this.soundCtrl.Name = "soundCtrl";
            this.soundCtrl.Size = new System.Drawing.Size(32, 32);
            this.soundCtrl.TabIndex = 8;
            this.soundCtrl.TabStop = false;
            // 
            // VictoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PICO.Properties.Resources.bg_1;
            this.ClientSize = new System.Drawing.Size(512, 512);
            this.Controls.Add(this.pausePanel);
            this.Name = "VictoryScreen";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            this.pausePanel.ResumeLayout(false);
            this.pausePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox74)).EndInit();
            this.panel1.ResumeLayout(false);
            this.option0.ResumeLayout(false);
            this.option0.PerformLayout();
            this.option1.ResumeLayout(false);
            this.option1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deathIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.berryIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clockIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundCtrl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pausePanel;
        private Panel panel1;
        private Panel option0;
        private Label label4;
        private Panel option1;
        private Label label5;
        private GroupBox groupBox2;
        private Label finalDeathCount;
        private PictureBox deathIcon;
        private Label finalTime;
        private PictureBox berryIcon;
        private PictureBox clockIcon;
        private Label finalBerryCount;
        private Label pausa;
        protected PictureBox soundCtrl;
        private PictureBox pictureBox74;
        private PictureBox pictureBox1;
    }
}