using System;
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
    public partial class Level2 : BaseLevel
    {
        public Level2()
        {
            InitializeComponent();
            GetAllControlsWithParameters("wall");
            ReorderControls();
            Bgm = new(GetBaseDirectory() + @"\bgm\level2.wav");
            UpdateSound(soundCtrl);
            currentRoom = 2;
            player.SetSpawnPoint(new Point(32, 448));
        }
        public Level2(int ticks, int deathCount, int berryCount)
        {
            timerTicks = ticks;
            updateDeaths(deathCount);
            updateBerries(berryCount);
            InitializeComponent();
            GetAllControlsWithParameters("wall");
            ReorderControls();
            Bgm = new(GetBaseDirectory() + @"\bgm\level2.wav");
            UpdateSound(soundCtrl);
            currentRoom = 2;
            player.SetSpawnPoint(new Point(32, 448));
        }
    }
}
