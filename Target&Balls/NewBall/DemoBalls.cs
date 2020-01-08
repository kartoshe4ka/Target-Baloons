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
        Target T;
        Point dot;

        public DemoBalls()
        {
            InitializeComponent();
        }
        
        private void DemoBalls_MouseDown(object sender, MouseEventArgs e)
        {
            if (T != null) //существование мишени на форме
                 T.Dispose(); 
            dot = new Point(e.X, e.Y);
            T = new Target(this, dot);

            T.Show(); //создание мишени
            G.ChangeVector(dot); // изменение вектора шарика
        }

        private void DemoBalls_Load(object sender, EventArgs e)
        {
            G = new Game(this);
        }
    }
}
