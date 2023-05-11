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

        public abstract List<Orb> GetOrbList();

        internal sealed class LogicApi : AbstractLogicApi
        {

            private List<Orb> orbs = new List<Orb>();

            public override List<Orb> GetOrbList()
            {
                return orbs;
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
                Random rand = new Random();
                orbs.Clear();
                for (int i = 0; i < num; i++)
                {
                    int x = rand.Next(10, 590);
                    int y = rand.Next(10, 590);
                    orbs.Add(new Orb(x, y, 20, 20));
                }

            }


            public override void CreateThreads()
            {
                List<Orb> orbs = GetOrbList();
                StopThreads = false;

                foreach (Orb orb in orbs)
                {
                    Thread watek = new Thread(() =>
                    {
                        Random rand = new Random();
                        int dx;
                        int dy;
                        while (!StopThreads)
                        {
                            dx = rand.Next(-5, 5);
                            dy = rand.Next(-5, 5);
                            orb.x += dx;
                            orb.y += dy;
                            while (orb.x < 10) orb.x += 20;
                            while (orb.x > 590) orb.x -= 20;
                            while (orb.y < 10) orb.y += 20;
                            while (orb.y > 590) orb.y -= 20;

                            Thread.Sleep(20);
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

