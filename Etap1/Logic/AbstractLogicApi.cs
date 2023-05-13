﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            private bool IsOverlapping(Orb newOrb)
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


            public override void GenerateRandomBalls(int num)
            {
                Random rand = new Random();
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

                            orb.x += orb.XSpeed;
                            orb.y += orb.YSpeed;
                           
                            CheckCollision(orb);

                            Thread.Sleep(15);
                           
                        }
                    });
                    watek.Start();
                }
            }

            private void AreaCollision(Orb orb)
            {
                if ((orb.x + orb.radius) >= DataApi.rightBorder())
                {
                    orb.XSpeed = -orb.XSpeed;
                    orb.x = DataApi.rightBorder() - orb.radius;
                }
                if (orb.x <= DataApi.leftBorder())
                {
                    orb.XSpeed = -orb.XSpeed;
                    orb.x = DataApi.leftBorder();
                }
                if ((orb.y + orb.radius) >= DataApi.downBorder())
                {
                    orb.YSpeed = -orb.YSpeed;
                    orb.y = DataApi.downBorder() - orb.radius;
                }
                if (orb.y <= DataApi.upBorder())
                {
                    orb.YSpeed = -orb.YSpeed;
                    orb.y = DataApi.upBorder();
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
                    double xDiff = o.x - orb.x;
                    double yDiff = o.y - orb.y;
                    double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff))*2;
                    if (distance <= (orb.radius + o.radius))
                    {
                        double newSpeed = ((o.XSpeed * (o.weight - orb.weight) + (orb.weight * orb.XSpeed * 2)) / (o.weight + orb.weight));
                        orb.XSpeed = ((orb.XSpeed * (orb.weight - o.weight) + (o.weight * o.XSpeed * 2)) / (o.weight + orb.weight));
                        o.XSpeed = newSpeed;

                        newSpeed = ((o.YSpeed * (o.weight - orb.weight)) + (orb.weight * orb.YSpeed * 2) / (o.weight + orb.weight));
                        orb.YSpeed = ((orb.YSpeed * (orb.weight - o.weight)) + (o.weight * o.YSpeed * 2) / (o.weight + orb.weight));
                        o.YSpeed = newSpeed;
                    }
                }
            }

            private void CheckCollision(Orb orb)
            {
                AreaCollision(orb);
                OrbCollision(orb);
            }

            public override void Stopthreads()
            {
                StopThreads = true;
            }
        }
    }
}

