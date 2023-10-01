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
    public partial class TitleMenu : Base
    {
    private readonly SoundPlayer launchSound = new(GetBaseDirectory() + @"\bgm\launch.wav");

        public TitleMenu()
        {
            Bgm = new(GetBaseDirectory() + @"\bgm\level0.wav");
            InitializeComponent();
            UpdateSound(soundCtrl);
            GetBaseDirectory();
        }

        private int currentAnimationFrame;
        private int currentCoolDownFrame;
        private bool gameWillStart;
        private const int MaxAnimationCooldown = 6;
        private readonly Color[] colors = new[]
        {
            Color.FromArgb(96, 96, 96),
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(126, 37, 84),
            Color.FromArgb(32, 43, 80),
        };

        private new void MainTimerEvent(object sender, EventArgs e)
        {
            if (gameWillStart)
            {
                OpenNextWindow(1);
            }
            if (currentAnimationFrame == 0)
            {
                return;
            }
            if (currentAnimationFrame > 0 && currentAnimationFrame <= 72)
            {

                if (currentCoolDownFrame == 0)
                {
                    if (currentAnimationFrame <= 60)
                    {
                        int currentColor = currentAnimationFrame % 2;
                        if (currentColor == 1)
                        {
                            logo.Image = Resources.logo_1;
                            labelPressBtn.ForeColor = colors[1];
                        }
                        else
                        {
                            logo.Image = Resources.logo_0;
                            labelPressBtn.ForeColor = colors[0];
                        }
                        //logo.Image = currentColor == 0 ? Resources.logo_1 : Resources.logo_0;
                        currentCoolDownFrame = MaxAnimationCooldown;
                    }
                    else
                    {
                        int currentColor = currentAnimationFrame % 2;
                        if (currentColor == 1)
                        {
                            logo.Image = Resources.logo_2;
                            labelPressBtn.ForeColor = colors[2];
                            labelCtrls.ForeColor = colors[2];
                        }
                        else
                        {
                            logo.Image = Resources.logo_3;
                            labelPressBtn.ForeColor = colors[3];
                            labelCtrls.ForeColor = colors[3];
                        }
                        //logo.Image = currentAnimationFrame % 2 == 1 ? Resources.logo_2 : Resources.logo_3;
                    }
                }
                else
                {
                    currentCoolDownFrame--;
                }

            }
            currentAnimationFrame++;
            if (currentAnimationFrame >= 76)
            {
                gameWillStart = true;
            }
        }

        private new void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && currentAnimationFrame == 0)
            {
                currentAnimationFrame = 1;
                if (SoundUp)
                {
                    Bgm.Stop();
                    launchSound.Play();
                }
            }
        }

        private void Sound_Click(object sender, EventArgs e)
        {
            SoundUp = !SoundUp;
            if (currentAnimationFrame == 0)
            {
                UpdateSound(soundCtrl);
            }
        }
    }
}
