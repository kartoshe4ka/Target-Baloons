using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewBall
{
    public partial class DemoBalls : Form
    {
        Game G;
        Point dot;

        public DemoBalls()
        {
            InitializeComponent();
        }
        
        private void DemoBalls_MouseDown(object sender, MouseEventArgs e)
        {
            dot = new Point(e.X, e.Y);
            G.Click(this, dot);
        }

        private void DemoBalls_Load(object sender, EventArgs e)
        {
            G = new Game(this);
        }
    }
}
