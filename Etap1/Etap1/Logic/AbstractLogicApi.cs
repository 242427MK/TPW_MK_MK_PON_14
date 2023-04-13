using System;
using System.Collections.Generic;
using System.Threading;
using Etap1.Data;

namespace Etap1.Logic
{
    public abstract class AbstractLogicApi
    {

        public static AbstractLogicApi CreateApi(AbstractDataApi abstractDataApi = null)
        {
            return new LogicApi(abstractDataApi);
        }

        public abstract void CreateScene(int width, int height, int ballQuantity, int ballRadius);

        public abstract List<Ball> GetBalls();

        public abstract void Enable();

        public abstract void Disable();

        public abstract bool IsEnabled();

        internal sealed class LogicApi : AbstractLogicApi
        {
            private AbstractDataApi dataApi;

            private Scene scene;

            public LogicApi(AbstractDataApi abstractDataApi = null)
            {
                if (abstractDataApi == null)
                {
                    this.dataApi = AbstractDataApi.CreateApi();
                }
                else
                {
                    this.dataApi = abstractDataApi;
                }
            }

            public override void CreateScene(int width, int height, int ballQuantity, int ballRadius)
            {
                this.scene = new Scene(width, height);
                scene.GenerateBallList(ballQuantity, ballRadius);
                foreach (Ball ball1 in scene.Balls)
                {
                    Thread thread = new Thread(() =>
                    {
                        int xDirection;
                        int yDirection;

                        while (true)
                        {
                            Random rng = new Random();

                            xDirection = rng.Next(-20, 20);
                            yDirection = rng.Next(-20, 20);

                            ball1.x += xDirection;
                            ball1.y += yDirection;

                            Thread.Sleep(15);
                        }
                    });
                    thread.Start();
                }
            }

            public override List<Ball> GetBalls()
            {
                return scene.Balls;
            }

            public override void Enable()
            {
                this.scene.Enabled = true;
            }

            public override void Disable()
            {
                this.scene.Enabled = false;
            }

            public override bool IsEnabled()
            {
                return this.scene.Enabled;
            }
        }
    }
}

