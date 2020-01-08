using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewBall
{
    class Baloon : BilliardsBall
    {
        Point targetPoint = new Point();
        public Baloon(Form f) : base(f)
        {
            this.Load("BlueBall.png");
            size = 15;
            Height = 2 * size;
            Width = 2 * size;
        }

        public void ChangeXY(Point dot)
        {
            t.Enabled = true;
            double k = 0.005;
            targetPoint = dot;

            vx = (dot.X - x) * k;
            vy = (dot.Y - y) * k;
        }

        public override void Move()
        {
            //проверка на попадание
            base.Move();
            if (Math.Abs(x - targetPoint.X) < 5 && Math.Abs(y - targetPoint.Y) < 5)
                t.Enabled = false;
        }
    }
    class Target : Ball
    {
        public Target(Form f, Point dot) : base(f)
        {
            this.Load("target.png");
            vx = vy = 0;
            x = dot.X;
            y = dot.Y;
        }
    }

    class Game
    {
        int n = 10;  // Кол-во шариков
        List<Ball> baloons = new List<Ball>();
        public Game(Form f)
        {
            for (int i = 0; i < n; i++)
            {
                Baloon ball = new Baloon(f);
                baloons.Add(ball);

                #region Круглый шар
                using (var gp = new GraphicsPath())
                {
                    gp.AddEllipse(new Rectangle(0, 0, baloons.Last().Width - 1, baloons.Last().Height - 1));
                    baloons.Last().Region = new Region(gp);
                }
                #endregion
            }
        }

        public void ChangeVector(Point dot)
        {
            foreach (Baloon b in baloons)
            {
                b.ChangeXY(dot);
            }
        }
    }
}