using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PICO
{
    public partial class Level4 : BaseLevel
    {

        public Level4()
        {
            InitializeComponent();
            UpdateWallList("wall");
            ReorderControls();
            Bgm = new(GetBaseDirectory() + @"\bgm\level4.wav");
            UpdateSound(soundCtrl);
            currentRoom = 4;
            player.SetSpawnPoint(new Point(32, 416));
        }
        public Level4(int ticks, int deathCount, int berryCount)
        {
            timerTicks = ticks;
            updateDeaths(deathCount);
            updateBerries(berryCount);
            InitializeComponent();
            UpdateWallList("wall");
            ReorderControls();
            Bgm = new(GetBaseDirectory() + @"\bgm\level4.wav");
            UpdateSound(soundCtrl);
            currentRoom = 4;
            player.SetSpawnPoint(new Point(32, 416));
        }
    }
}
