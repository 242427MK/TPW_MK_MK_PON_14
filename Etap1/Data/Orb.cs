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
        private double Radius;
        private double Weight;
        private double[] speed = new double[2];

        private bool StopThreads = false;

        private Vector2 _vector;

        public Orb(double x, double y, double radius, double weight)
        {
            _vector = new Vector2((float)x, (float)y);
            Radius = radius;
            Weight = weight;

            Random random = new Random();
            double xSpeed = 0;
            do
            {
                xSpeed = random.NextDouble() * 0.99;
            } while (xSpeed == 0);
            double ySpeed = Math.Sqrt(4 - (xSpeed * xSpeed));
            ySpeed = (random.Next(-1, 1) < 0) ? ySpeed : -ySpeed;
            speed[0] = xSpeed;
            speed[1] = ySpeed;

            Stopwatch stopwatch = new Stopwatch();

            Thread watek = new Thread(() =>
            {
                while (!StopThreads)
                {
                    stopwatch.Restart();
                    stopwatch.Start();
                    Move();
                    stopwatch.Stop();

                    int sleepTime = (int)(stopwatch.Elapsed.TotalMilliseconds);
                    Thread.Sleep(sleepTime);
                }
            });
            watek.Start();

        }

        public void stop()
        {
            this.StopThreads = true;
        }

        public float x
        {
            get { return _vector.X; }
            set
            {
                _vector.X = value;
                OnPropertyChanged("x");
            }
        }

        public float y
        {
            get { return _vector.Y; }
            set
            {
                _vector.Y = value;
                OnPropertyChanged("y");
            }
        }

        private void Move()
        {
                _vector.X += (float)XSpeed;
                _vector.Y += (float)YSpeed;
        }

        public double radius
        {
            get { return Radius; }
            set
            {
                Radius = value;
                OnPropertyChanged("radius");
            }
        }

        public double XSpeed
        {
            get { return speed[0]; }
            set { speed[0] = value; }
        }

        public double YSpeed
        {
            get { return speed[1]; }
            set { speed[1] = value; }
        }

        public double weight
        {
            get { return Weight; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}