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
    public partial class Level3 : BaseLevel
    {
        public Level3()
        {
            InitializeComponent();
            UpdateWallList("wall");
            ReorderControls();
            Bgm = new(GetBaseDirectory() + @"\bgm\level3.wav");
            UpdateSound(soundCtrl);
            currentRoom = 3;
            player.SetSpawnPoint(new Point(32, 416));
        }
        public Level3(int ticks, int deathCount, int berryCount)
        {
            timerTicks = ticks;
            updateDeaths(deathCount);
            updateBerries(berryCount);
            InitializeComponent();
            UpdateWallList("wall");
            ReorderControls();
            Bgm = new(GetBaseDirectory() + @"\bgm\level3.wav");
            UpdateSound(soundCtrl);
            currentRoom = 3;
            player.SetSpawnPoint(new Point(32, 416));
        }
    }
}
