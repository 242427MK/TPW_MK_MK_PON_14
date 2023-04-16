using System;
using System.Collections.Generic;


namespace Logic
{
    public class Scene
    {
        private readonly int width;
        private readonly int height;
        private bool enabled = false;

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

        public void GenerateBallList(int ballQuantity, int ballRadius)
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
