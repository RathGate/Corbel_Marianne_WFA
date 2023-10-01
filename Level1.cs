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
    public partial class Level1 : BaseLevel
    {
        public Level1()
        {
            InitializeComponent();
            player.SetSpawnPoint(new Point(32, 384));
            GetAllControlsWithParameters("wall");
            ReorderControls();
            UpdateSound(soundCtrl);
        }
    }
}
