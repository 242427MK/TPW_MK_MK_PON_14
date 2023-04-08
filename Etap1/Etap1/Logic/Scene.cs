using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etap1.Logic
{
    public class Scene
    {
        private readonly int width;
        private readonly int height;


        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Scene(int Width, int Height)
        {
            width = Width;
            height = Height;
        }

        private bool enabled = false;
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        private readonly List<Ball> balls = new List<Ball>();
        public List<Ball> Balls
        {
            get { return balls; }
        }

        public void GenerateOrbList(int ballQuantity, int ballRadius)
        {
            balls.Clear();
            Random rng = new Random();
            for (int i = 0; i < ballQuantity; i++)
            {
                int x = rng.Next(ballRadius, width - ballRadius);
                int y = rng.Next(ballRadius, height - ballRadius);
                this.balls.Add(new Ball(x, y, ballRadius));
            }
        }
    }
}
