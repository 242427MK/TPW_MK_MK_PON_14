using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public abstract class AbstractLogicApi
    {
        private static AbstractLogicApi Instance = new LogicApi();

        public static AbstractLogicApi CreateNewInstance(AbstractDataApi dataApi)
        {
            return new LogicApi(dataApi);
        }

        public static AbstractLogicApi instance
        {
            get { return Instance; }
        }

        public abstract void GenerateRandomBalls(int num);

        public abstract void CreateThreads();

        public abstract void Stopthreads();

        public abstract List<Ball> GetBallList();

        internal sealed class LogicApi : AbstractLogicApi
        {

            private List<Ball> balls = new List<Ball>();

            public override List<Ball> GetBallList()
            {
                return balls;
            }
            internal LogicApi()
            {
                DataApi = AbstractDataApi.instance;
            }

            internal LogicApi(AbstractDataApi dataApi)
            {
                this.DataApi = dataApi;
            }

            AbstractDataApi DataApi;

            private bool StopThreads = false;

            public override void GenerateRandomBalls(int num)
            {
                List<Orb> orbs = DataApi.GetOrbList();
                orbs.Clear();
                Random rand = new Random();

                for (int i = 0; i < num; i++)
                {
                    int x = rand.Next(10, 590);
                    int y = rand.Next(10, 590);
                    orbs.Add(new Orb(x, y));
                }
                //List<Ball> balls = new List<Ball>();
                balls.Clear();
                for (int i = 0; i<orbs.Count; i++)
                {
                    balls.Add(new Ball(orbs[i]));
                }
            }


            public override void CreateThreads()
            {
                List<Ball> balls = GetBallList();
                StopThreads = false;

                foreach (Ball ball in balls)
                {
                    Thread watek = new Thread(() =>
                    {
                        Random rand = new Random();
                        int dx = rand.Next(-10, 10);
                        int dy = rand.Next(-10, 10);
                        while (!StopThreads)
                        {
                            ball.x += dx;
                            ball.y += dy;
                            while (ball.x < 10) ball.x += 30;
                            while (ball.x > 590) ball.x -= 30;
                            while (ball.y < 10) ball.y += 30;
                            while (ball.y > 590) ball.y -= 30;

                            Thread.Sleep(16);
                        }
                    });
                    watek.Start();
                }
            }

            public override void Stopthreads()
            {
                StopThreads = true;
            }
        }
    }
}

