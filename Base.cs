﻿using PICO.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace PICO
{
    public partial class Base : Form
    {
        protected bool SoundUp; 
        protected SoundPlayer Bgm = new();
        protected int currentRoom;
        protected Font customFont;

        public Base()
        {
            InitializeComponent();
            SoundUp = true;
        }
        public Base(bool soundUp)
        {
            InitializeComponent();
            SoundUp = soundUp;
        }

        protected void MainTimerEvent(object sender, EventArgs e)
        {

        }

        protected void OnKeyDown(object sender, KeyEventArgs e)
        {

        }

        protected void OnKeyUp(object sender, KeyEventArgs e)
        {

        }

        protected string GetElapsedTime(int ticks)
        {
            int interval = mainTimer.Interval;
            TimeSpan t = TimeSpan.FromMilliseconds((ticks * 25));
            return $"{t.Hours:00}:{t.Minutes:00}:{t.Seconds:00}";
        }


        protected void UpdateSound(PictureBox soundCtrl)
        {
            if (SoundUp)
            {
                soundCtrl.Image = Resources.sound_up;
                Bgm.PlayLooping();
                return;
            }

            soundCtrl.Image = Resources.sound_down;
            Bgm.Stop();
        }

        protected void OpenNextWindow(int roomIndex)
        {
            Form newWindow;
            switch (roomIndex)
            {
                case 1:
                    newWindow = new Level1();
                    break;
                case 2: 
                    newWindow = new Level2();
                    break;
                case 3:
                    newWindow = new Level3();
                    break;
                case 4:
                    newWindow = new Level4();
                    break;
                case 5:
                    newWindow = new VictoryScreen();
                    break;
                default:
                    newWindow = new TitleMenu();
                    break;
            }
            newWindow.Location = this.Location;
            newWindow.Show();
            this.Close();
        }
        protected void OpenNextWindow(int roomIndex, int ticks, int deathCount, int berryCount)
        {
            Form newWindow;
            switch (roomIndex)
            {
                case 1:
                    newWindow = new Level1(ticks, deathCount, berryCount);
                    break;
                case 2:
                    newWindow = new Level2(ticks, deathCount, berryCount);
                    break;
                case 3:
                    newWindow = new Level3(ticks, deathCount, berryCount);
                    break;
                case 4:
                    newWindow = new Level4(ticks, deathCount, berryCount);
                    break;
                case 5:
                    newWindow = new VictoryScreen(ticks, deathCount, berryCount);
                    break;
                default:
                    newWindow = new TitleMenu();
                    break;
            }
            newWindow.Location = this.Location;
            newWindow.Show();
            this.Close();
        }

        // Returns the directory where program.cs is situated.
        protected static string GetBaseDirectory()
        {
            var directory = System.AppContext.BaseDirectory.Split(Path.DirectorySeparatorChar);
            var slice = new ArraySegment<string>(directory, 0, directory.Length - 4);
            var path = Path.Combine(slice.ToArray());

            Debug.WriteLine($"Path of Program.cs is: {path}");
            return path;
        }
    }
}
