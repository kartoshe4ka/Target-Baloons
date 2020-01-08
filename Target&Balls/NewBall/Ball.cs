using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewBall
{
    class Ball:PictureBox
    {
        protected double x, y;
        protected double vx, vy;
        protected int size = 30;
        protected Form parent;
        protected Timer t = new Timer();
        
        static Random rnd = new Random();
        public Ball(Form f)
        {
            parent = f;
            x = rnd.Next(size, parent.ClientSize.Width - size);
            y = rnd.Next(size, parent.ClientSize.Height - size);
            vx = (rnd.NextDouble() - 0.5) * 10;
            vy = (rnd.NextDouble() - 0.5) * 10;
            parent.Controls.Add(this);

            this.Load("ball.png");
            this.Width = 2 * size;
            this.Height = 2 * size;
            
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            t.Enabled = true;
            t.Interval = 1;
            t.Tick += T_Tick;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            Move();
            Show();
        }

        public virtual void Move()
        {
            x += vx;
            y += vy;
        }

        public void Show()
        {
            this.Top = (int)y - size;
            this.Left = (int)x - size;
        }

    }

    class BilliardsBall : Ball
    {
        public BilliardsBall(Form f): base(f)
        { }
        public override void Move()
        {
            base.Move();
            if (x < size) vx = -vx; 
            if (y < size) vy = -vy;
            if (x > parent.ClientSize.Width - size) vx = -vx;
            if (y > parent.ClientSize.Height - size) vy = -vy;
        }
    }
}
