using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PICO.Properties;

namespace PICO
{
    public partial class MainMenu : Form
    {
        private int currentAnimationFrame = 0;
        private int currentCoolDownFrame = 0;
        private bool gameWillStart = false;
        private int maxAnimationCooldown = 6;
        private readonly Color[] colors = new[]
        {
            Color.FromArgb(96, 96, 96), 
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(126, 37, 84),
            Color.FromArgb(32, 43, 80),
        };

        public MainMenu()
        {
            InitializeComponent();
        }

        private void mainMenuTimer_Tick(object sender, EventArgs e)
        {
            if (gameWillStart)
            {
                Form newForm = new Form1();
                newForm.Location = this.Location;
                newForm.Show();
                this.Close();
                return;
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
                        currentCoolDownFrame = maxAnimationCooldown;
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

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                currentAnimationFrame = 1;
            }
        }
    }
}
