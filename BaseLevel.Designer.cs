namespace PICO
{
    partial class BaseLevel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseLevel));
            this.soundCtrl = new System.Windows.Forms.PictureBox();
            this.snowball = new System.Windows.Forms.PictureBox();
            this.timeElapsed = new System.Windows.Forms.Label();
            this.player = new PICO.BaseLevel.Player();
            this.pausePanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pauseOption0 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pauseOption1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.deathCount = new System.Windows.Forms.Label();
            this.BerryIcon = new System.Windows.Forms.PictureBox();
            this.deathIcon = new System.Windows.Forms.PictureBox();
            this.berryCount = new System.Windows.Forms.Label();
            this.pausa = new System.Windows.Forms.Label();
            this.pauseTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.soundCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snowball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.pausePanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pauseOption0.SuspendLayout();
            this.pauseOption1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BerryIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deathIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTimer
            // 
            this.mainTimer.Tick += new System.EventHandler(this.MainGameTimerEvent);
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
            // snowball
            // 
            this.snowball.BackColor = System.Drawing.Color.Transparent;
            this.snowball.Image = ((System.Drawing.Image)(resources.GetObject("snowball.Image")));
            this.snowball.InitialImage = null;
            this.snowball.Location = new System.Drawing.Point(513, 384);
            this.snowball.MinimumSize = new System.Drawing.Size(24, 24);
            this.snowball.Name = "snowball";
            this.snowball.Size = new System.Drawing.Size(32, 32);
            this.snowball.TabIndex = 85;
            this.snowball.TabStop = false;
            this.snowball.Tag = "snowball";
            // 
            // timeElapsed
            // 
            this.timeElapsed.AutoSize = true;
            this.timeElapsed.Font = new System.Drawing.Font("Early GameBoy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeElapsed.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timeElapsed.Location = new System.Drawing.Point(12, 12);
            this.timeElapsed.Margin = new System.Windows.Forms.Padding(0);
            this.timeElapsed.Name = "timeElapsed";
            this.timeElapsed.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.timeElapsed.Size = new System.Drawing.Size(169, 30);
            this.timeElapsed.TabIndex = 84;
            this.timeElapsed.Text = "00:00:00";
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::PICO.Properties.Resources.maddy_7;
            this.player.Location = new System.Drawing.Point(32, 384);
            this.player.MinimumSize = new System.Drawing.Size(32, 32);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(32, 32);
            this.player.TabIndex = 83;
            this.player.TabStop = false;
            this.player.Tag = "player";
            // 
            // pausePanel
            // 
            this.pausePanel.Controls.Add(this.groupBox1);
            this.pausePanel.Controls.Add(this.deathCount);
            this.pausePanel.Controls.Add(this.BerryIcon);
            this.pausePanel.Controls.Add(this.deathIcon);
            this.pausePanel.Controls.Add(this.berryCount);
            this.pausePanel.Controls.Add(this.pausa);
            this.pausePanel.Controls.Add(this.soundCtrl);
            this.pausePanel.Location = new System.Drawing.Point(0, 0);
            this.pausePanel.MaximumSize = new System.Drawing.Size(512, 512);
            this.pausePanel.MinimumSize = new System.Drawing.Size(512, 512);
            this.pausePanel.Name = "pausePanel";
            this.pausePanel.Size = new System.Drawing.Size(512, 512);
            this.pausePanel.TabIndex = 86;
            this.pausePanel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pauseOption0);
            this.groupBox1.Controls.Add(this.pauseOption1);
            this.groupBox1.Location = new System.Drawing.Point(96, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 136);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            // 
            // pauseOption0
            // 
            this.pauseOption0.Controls.Add(this.label1);
            this.pauseOption0.Location = new System.Drawing.Point(1, 34);
            this.pauseOption0.Name = "pauseOption0";
            this.pauseOption0.Size = new System.Drawing.Size(318, 32);
            this.pauseOption0.TabIndex = 85;
            this.pauseOption0.Tag = "pauseOption";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Early GameBoy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(32, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "continue";
            // 
            // pauseOption1
            // 
            this.pauseOption1.Controls.Add(this.label3);
            this.pauseOption1.Location = new System.Drawing.Point(1, 76);
            this.pauseOption1.Name = "pauseOption1";
            this.pauseOption1.Size = new System.Drawing.Size(318, 34);
            this.pauseOption1.TabIndex = 86;
            this.pauseOption1.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Early GameBoy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.label3.Location = new System.Drawing.Point(32, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "reset cartridge";
            // 
            // deathCount
            // 
            this.deathCount.AutoSize = true;
            this.deathCount.Font = new System.Drawing.Font("Early GameBoy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deathCount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deathCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deathCount.Location = new System.Drawing.Point(401, 55);
            this.deathCount.Margin = new System.Windows.Forms.Padding(0);
            this.deathCount.Name = "deathCount";
            this.deathCount.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.deathCount.Size = new System.Drawing.Size(65, 30);
            this.deathCount.TabIndex = 82;
            this.deathCount.Text = "0 x";
            this.deathCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BerryIcon
            // 
            this.BerryIcon.BackgroundImage = global::PICO.Properties.Resources.berryIcon;
            this.BerryIcon.Location = new System.Drawing.Point(469, 12);
            this.BerryIcon.Name = "BerryIcon";
            this.BerryIcon.Size = new System.Drawing.Size(32, 32);
            this.BerryIcon.TabIndex = 81;
            this.BerryIcon.TabStop = false;
            // 
            // deathIcon
            // 
            this.deathIcon.BackgroundImage = global::PICO.Properties.Resources.skullIcon;
            this.deathIcon.Location = new System.Drawing.Point(469, 53);
            this.deathIcon.Name = "deathIcon";
            this.deathIcon.Size = new System.Drawing.Size(32, 32);
            this.deathIcon.TabIndex = 83;
            this.deathIcon.TabStop = false;
            // 
            // berryCount
            // 
            this.berryCount.AutoSize = true;
            this.berryCount.Font = new System.Drawing.Font("Early GameBoy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.berryCount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.berryCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.berryCount.Location = new System.Drawing.Point(401, 12);
            this.berryCount.Margin = new System.Windows.Forms.Padding(0);
            this.berryCount.Name = "berryCount";
            this.berryCount.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.berryCount.Size = new System.Drawing.Size(65, 30);
            this.berryCount.TabIndex = 20;
            this.berryCount.Text = "0 x";
            this.berryCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pausa
            // 
            this.pausa.AutoSize = true;
            this.pausa.Font = new System.Drawing.Font("Early GameBoy", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pausa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.pausa.Location = new System.Drawing.Point(161, 157);
            this.pausa.Name = "pausa";
            this.pausa.Size = new System.Drawing.Size(205, 47);
            this.pausa.TabIndex = 80;
            this.pausa.Text = "Pausa";
            // 
            // pauseTimer
            // 
            this.pauseTimer.Interval = 20;
            this.pauseTimer.Tick += new System.EventHandler(this.pauseTimer_Tick);
            // 
            // BaseLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 512);

            this.Controls.Add(this.snowball);
            this.Controls.Add(this.player);
            this.Controls.Add(this.pausePanel);
            this.Controls.Add(this.timeElapsed);
            this.Name = "BaseLevel";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.soundCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snowball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.pausePanel.ResumeLayout(false);
            this.pausePanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.pauseOption0.ResumeLayout(false);
            this.pauseOption0.PerformLayout();
            this.pauseOption1.ResumeLayout(false);
            this.pauseOption1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BerryIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deathIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected PictureBox soundCtrl;
        private PictureBox snowball;
        private Label timeElapsed;
        protected BaseLevel.Player player;
        private Panel pausePanel;
        private GroupBox groupBox1;
        private Panel pauseOption0;
        private Label label1;
        private Panel pauseOption1;
        private Label label3;
        private Label deathCount;
        private PictureBox BerryIcon;
        private PictureBox deathIcon;
        private Label berryCount;
        private Label pausa;
        protected System.Windows.Forms.Timer pauseTimer;
    }
}