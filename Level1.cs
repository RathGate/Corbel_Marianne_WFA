﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PICO
{
    public partial class Level1 : BaseLevel
    {
        public Level1()
        {
            InitializeComponent();
            player.SetSpawnPoint(new Point(32, 384));
            UpdateWallList("wall");
            ReorderControls();
            currentRoom = 1;
            updateDeaths(0);
            updateBerries(0);
            Bgm = new(GetBaseDirectory() + @"\bgm\level1.wav");
            UpdateSound(soundCtrl);
        }
        public Level1(int ticks, int deathCount, int berryCount)
        {
            timerTicks = ticks;
            updateDeaths(deathCount);
            updateBerries(berryCount);
            InitializeComponent();
            player.SetSpawnPoint(new Point(32, 384));
            UpdateWallList("wall");
            ReorderControls();
            currentRoom = 1;
            Bgm = new(GetBaseDirectory() + @"\bgm\level1.wav");
            UpdateSound(soundCtrl);
        }

        private void soundCtrl_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox75_Click(object sender, EventArgs e)
        {

        }

        private void pauseTimer_Tick(object sender, EventArgs e)
        {

        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox74_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox72_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox71_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox70_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox69_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox68_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox67_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox65_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox66_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox61_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox59_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox58_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox57_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox55_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox56_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox54_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox53_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox76_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox77_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox78_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox79_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox80_Click(object sender, EventArgs e)
        {

        }
    }
}
