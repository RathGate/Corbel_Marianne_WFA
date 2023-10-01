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
using static PICO.BaseLevel;

namespace PICO
{
    public partial class VictoryScreen : Base
    {
        private bool Up, Down;
        private int inputY;

        private int _currentOption;
        private int currentOption
        {
            get { return _currentOption; }
            set
            {
                _currentOption = value < 0 ? 1 : value > 1 ? 0 : value;
            }
        }
        private int optionChangeCooldown = 0;
        private List<Panel> options;

        public VictoryScreen()
        {
            InitializeComponent();
            options = new List<Panel>() { option0, option1};
        }
        public VictoryScreen(int ticks, int deathCount, int berryCount)
        {
            InitializeComponent();
            options = new List<Panel>() { option0, option1};
            finalTime.Text = GetElapsedTime(ticks);
            finalDeathCount.Text = "x " + deathCount;
            finalBerryCount.Text = "x " + berryCount;
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            inputY = Down ? 1 : Up ? -1 : 0;
            optionChangeCooldown = optionChangeCooldown < 0 ? 0 : optionChangeCooldown - 1;
            if (optionChangeCooldown == 0 && inputY != 0)
            {
                if (inputY > 0)
                {
                    currentOption++;
                }
                else
                {
                    currentOption--;
                }

                optionChangeCooldown = 4;
                UpdatePauseOption();
            }
            Debug.WriteLine(currentOption);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                Up = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                Down = false;
            }


        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                Up = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                Down = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (currentOption == 0)
                {
                    OpenNextWindow(0);
                    return;
                }
                this.Close();
            }
        }

        private void UpdatePauseOption()
            {
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == currentOption)
                    {
                        options[i].Controls.OfType<Label>().First().ForeColor = Color.White;
                        continue;
                    }
                    options[i].Controls.OfType<Label>().First().ForeColor = Color.FromArgb(96, 96, 96);
                }
            }





    }
}
