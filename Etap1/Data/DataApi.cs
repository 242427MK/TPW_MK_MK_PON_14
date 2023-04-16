using System;
using System.Threading;
using System.Collections.Generic;

namespace Data
{


    internal sealed class DataApi : AbstractDataApi
    {
        private readonly object locked = new object();

        private readonly object barrier = new object();

        private int queue = 0;

        private bool enabled = false;

        private Scene scene;

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public override Scene Scene
        {
            get { return scene; }
        }

        public override void CreateScene(int width, int height, int orbQuantity, int orbRadius)
        {
            this.scene = new Scene(width, height, orbQuantity, orbRadius);
            this.Enabled = true;
            List<Ball> balls = GetBalls();

            foreach (Ball ball1 in balls)
            {
                Thread t = new Thread(() => {
                    while (this.Enabled)
                    {
                        lock (locked)
                        {
                            ball1.move();
                        }

                        Thread.Sleep(5);
                    }
                });
                t.Start();
            }
        }

        public override List<Ball> GetBalls()
        {
            return Scene.balls;
        }

        public override void Disable()
        {
            this.Enabled = false;
        }
    }
}



