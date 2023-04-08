using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etap1.Logic
{
    public class BallLogic
    {
        private Ball ball;

        public BallLogic(Ball ball1)
        {
            ball = ball1;
        }

        public double x
        {
            get { return ball.x; }
            set
            {
                ball.x = value;
            }
        }
        public double y
        {
            get { return ball.y; }
            set
            {
                ball.y = value;
            }
        }
        public double radius
        {
            get { return ball.radius; }
            set
            {
                ball.radius = value;
            }
        }
    }
}
