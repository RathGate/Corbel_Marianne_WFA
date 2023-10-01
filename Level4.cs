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
            GetAllControlsWithParameters("wall");
            ReorderControls();
            UpdateSound(soundCtrl);
            currentRoom = 4;
            player.SetSpawnPoint(new Point(32, 416));
        }
        public Level4(int ticks, int deathCount, int berryCount)
        {
            timerTicks = ticks;
            Deaths = deathCount;
            Berries = berryCount;
            InitializeComponent();
            GetAllControlsWithParameters("wall");
            ReorderControls();
            UpdateSound(soundCtrl);
            currentRoom = 4;
            player.SetSpawnPoint(new Point(32, 416));
        }
    }
}
