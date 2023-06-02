using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
            private Logger logger;

            public override List<Orb> GetOrbList()
            {
                return orbs;
            }
            internal LogicApi()
            {
                DataApi = AbstractDataApi.instance;
                logger = new Logger(orbs);
            }

            internal LogicApi(AbstractDataApi dataApi)
            {
                this.DataApi = dataApi;
                logger = new Logger(orbs);
            }

            AbstractDataApi DataApi;

            private bool StopThreads = false;

            private bool IsOverlapping(Orb newOrb)
            {
                object lockObject = new object();

                lock (lockObject)
                {
                    foreach (Orb orb in orbs)
                    {
                        if (Math.Sqrt(Math.Pow(newOrb.x - orb.x, 2) + Math.Pow(newOrb.y - orb.y, 2)) < newOrb.radius + orb.radius)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }


            public override void GenerateRandomBalls(int num)
            {
                Random rand = new Random();
                logger.Stop();
                orbs.Clear();
                for (int i = 0; i < num; i++)
                {
                    int x = rand.Next(10, 590);
                    int y = rand.Next(10, 590);
                    Orb newOrb = new Orb(x, y, 20, 20);
                    while (IsOverlapping(newOrb)) // sprawdzenie czy nowa kula nie nachodzi na inne kulki w liście
                    {
                        x = rand.Next(10, 590);
                        y = rand.Next(10, 590);
                        newOrb = new Orb(x, y, 20, 20);
                    }
                    orbs.Add(newOrb);  
                }
                logger = new Logger(orbs);
            }

            

            public override void CreateThreads()
            {
                List<Orb> orbs = GetOrbList();
                StopThreads = false;

                object lockObject = new object();
                Stopwatch stopwatch = new Stopwatch();

                foreach (Orb orb in orbs)
                {
                    Thread watek = new Thread(() =>
                    {
                        while (!StopThreads)
                        {
                            stopwatch.Restart();
                            stopwatch.Start();  
                            lock (lockObject)
                            {
                                AreaCollision(orb);
                                OrbCollision(orb);
                            }
                            stopwatch.Stop();
                           
                            int sleepTime = (int)(stopwatch.Elapsed.TotalMilliseconds);
                            Thread.Sleep(sleepTime);
                        }
                    });
                    watek.Start();
                }

            }

            private void AreaCollision(Orb orb)
            {
                object lockObject = new object();
                lock (lockObject)
                {
                    {
                        if ((orb.x + orb.radius) >= DataApi.rightBorder())
                        {
                            orb.XSpeed = -orb.XSpeed;
                            orb.x = ((float)(DataApi.rightBorder() - orb.radius));
                        }
                        if (orb.x <= DataApi.leftBorder())
                        {
                            orb.XSpeed = -orb.XSpeed;
                            orb.x = DataApi.leftBorder();
                        }
                        if ((orb.y + orb.radius) >= DataApi.downBorder())
                        {
                            orb.YSpeed = -orb.YSpeed;
                            orb.y = ((float)(DataApi.downBorder() - orb.radius));
                        }
                        if (orb.y <= DataApi.upBorder())
                        {
                            orb.YSpeed = -orb.YSpeed;
                            orb.y = DataApi.upBorder();
                        }
                    }
                }
            }

            private void OrbCollision(Orb orb)
            {
                foreach (Orb o in orbs)
                {
                    if (o == orb)
                    {
                        continue;
                    }
                    object lockObject = new object();
                    double xDiff;
                    double yDiff;
                    lock (lockObject)
                    {
                         xDiff = o.x - orb.x;
                         yDiff = o.y - orb.y;
                    }
                    double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff))*2;
                    if (distance <= (orb.radius + o.radius))
                    {
                        float newSpeed = ((o.XSpeed * (o.weight - orb.weight) + (orb.weight * orb.XSpeed * 2)) / (o.weight + orb.weight));
                        orb.XSpeed = ((orb.XSpeed * (orb.weight - o.weight) + (o.weight * o.XSpeed * 2)) / (o.weight + orb.weight));
                        o.XSpeed = newSpeed;

                        newSpeed = ((o.YSpeed * (o.weight - orb.weight)) + (orb.weight * orb.YSpeed * 2) / (o.weight + orb.weight));
                        orb.YSpeed = ((orb.YSpeed * (orb.weight - o.weight)) + (o.weight * o.YSpeed * 2) / (o.weight + orb.weight));
                        o.YSpeed = newSpeed;
                    }
                }
            }

            public override void Stopthreads()
            {
                StopThreads = true;
                foreach (Orb orb in orbs)
                {
                    orb.stop();
                }
                logger.Stop();
            }
        }
    }
}

