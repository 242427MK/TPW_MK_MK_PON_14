using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Scene
    {
        private readonly int Width;

        private readonly int Height;

        private bool Enabled = false;

        private readonly List<Ball> Balls = new List<Ball>();


        public int width
        {
            get { return Width; }
        }


        public int height
        {
            get { return Height; }
        }


        public bool enabled
        {
            get { return Enabled; }
            set { Enabled = value; }
        }


        public List<Ball> balls
        {
            get { return Balls; }
        }

        public Ball GenerateBall(int radius)
        {
            Random random = new Random();
            bool valid = true;
            int x = 0;
            int y = 0;
            do
            {
                valid = true;
                x = random.Next(radius, this.width - radius);
                y = random.Next(radius, this.height - radius);
                foreach (Ball b1 in this.Balls)
                {
                    double distance = Math.Sqrt(((b1.x - x) * (b1.x - x)) + ((b1.y - y) * (b1.y - y)));
                    if (distance <= b1.radius + radius)
                    {
                        valid = false;
                        break;
                    };
                }
                if (!valid)
                {
                    continue;
                };
                valid = true;

            } while (!valid);

            return new Ball(x, y, radius);
        }

        public void GenerateBallList(int orbQuantity, int orbRadius)
        {
            Balls.Clear();
            for (int i = 0; i < orbQuantity; i++)
            {
                Ball b2 = GenerateBall(orbRadius);
                this.Balls.Add(b2);
            }
        }

        public Scene(int width, int height, int orbQuantity, int orbRadius)
        {
            Width = width;
            Height = height;
            GenerateBallList(orbQuantity, orbRadius);
        }
    }
}
