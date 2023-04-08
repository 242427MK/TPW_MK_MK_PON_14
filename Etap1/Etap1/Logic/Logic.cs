using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etap1.Logic
{
    public abstract class Logic {

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
                foreach (Ball ball in scene.Balls)
                {
                    Thread thread = new Thread(() =>
                    {
                        int xDirection;
                        int yDirection;

                        //while (this.scene.Enabled)
                        while (true)
                        {
                            Random rng = new Random();
                            xDirection = rng.Next(-20, 20);
                            yDirection = rng.Next(-20, 20);
                            //while ((orb.X + xDirection - orbRadius) >= 0 && (orb.X + xDirection - orbRadius) <= scene.Width)
                            //{
                            orb.X += xDirection;
                            //}
                            //while ((orb.Y + yDirection - orbRadius) >= 0 && (orb.Y + yDirection - orbRadius) <= scene.Height)
                            //{
                            orb.Y += yDirection;
                            //}
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
}
