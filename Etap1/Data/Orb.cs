using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Orb : INotifyPropertyChanged
    {
        private float Radius;
        private float Weight;
        private Vector2 SpeedVector;
        private Vector2 Position;
        private bool StopThreads = false;
        private float SpeedVectorLength;
        

        public Orb(float x, float y, float radius, float weight)
        {
            Position = new Vector2(x, y);
            Radius = radius;
            Weight = weight;

            Random random = new Random();
            float xSpeed = 0;
            do
            {
                xSpeed = (float)(random.NextDouble() * 0.99);
            } while (xSpeed == 0);
            float ySpeed = (float)Math.Sqrt(4 - (xSpeed * xSpeed));
            ySpeed = (random.Next(-1, 1) < 0) ? ySpeed : -ySpeed;
            SpeedVector = new Vector2(xSpeed, ySpeed);
            SpeedVectorLength = (float)Math.Sqrt(speedVector.X * speedVector.X + speedVector.Y * speedVector.Y); ;

            Stopwatch stopwatch = new Stopwatch();

            Thread watek = new Thread(() =>
            {
                while (!StopThreads)
                {
                    stopwatch.Restart();
                    stopwatch.Start();
                    Move();
                    stopwatch.Stop();
                    CalculateSpeedVectorLength();

                    int sleepTime = (int)(stopwatch.Elapsed.TotalMilliseconds + SpeedVectorLength);
                    sleepTime = Math.Max(sleepTime, 0)+1;
                    Thread.Sleep(sleepTime);
                }
            });
            watek.Start();

        }

        public void stop()
        {
            this.StopThreads = true;
        }

        private void Move()
        {
            Position += speedVector;
            OnPropertyChanged();
        }

        public float radius
        {
            get { return Radius; }
            set
            {
                Radius = value;
            }
        }

        public float x
        {
            get { return Position.X; }
            set
            {
                Position.X = value;
            }
        }

        public float y
        {
            get { return Position.Y; }
            set
            {
                Position.Y = value;
            }
        }

        public Vector2 position
        {
            get { return Position; }
            set
            {
                Position = value;
            }
        }

        public float XSpeed
        {
            get { return SpeedVector.X; }
            set
            {
                SpeedVector.X = value;
            }
        }
        public float YSpeed
        {
            get { return SpeedVector.Y; }
            set
            {
                SpeedVector.Y = value;
            }
        }

        public Vector2 speedVector
        {
            get { return SpeedVector; }
            set
            {
                SpeedVector = value;
            }
        }

        private void CalculateSpeedVectorLength()
        {
            float length = (float)Math.Sqrt(speedVector.X * speedVector.X + speedVector.Y * speedVector.Y);
            SpeedVectorLength = length;
        }

        public float weight
        {
            get { return Weight; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}