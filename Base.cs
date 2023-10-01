using PICO.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PICO
{
    public partial class Base : Form
    {
        protected bool SoundUp; 
        protected SoundPlayer Bgm = new();

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

        protected void OpenNewWindow(Form newWindow)
        {
            newWindow.Location = this.Location;
            newWindow.Show();
            this.Close();
        }
    }
}
