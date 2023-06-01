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
       // private double X;
       // private double Y;
        private double Radius;
        private double Weight;
        private double[] speed = new double[2];
        private double speedVector;

        private bool StopThreads = false;

        private Vector2 _vector;

        public Orb(double x, double y, double radius, double weight)
        {
            _vector = new Vector2((float)x, (float)y);
           // setXY(x, y);
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

            speedVector = Math.Sqrt((XSpeed * XSpeed) + (YSpeed * YSpeed));

           
                    Move();
                    updateSpeedVector();
                    int sleepTime = (int)(20 / speedVector);
                    sleepTime = Math.Max(sleepTime, 0);
                    
        }


        public void updateSpeedVector()
        {
          speedVector  = Math.Sqrt((this.XSpeed * this.XSpeed) + (this.YSpeed * this.YSpeed));
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

        /* private void setXY(double x, double y)
         {
             object lockObject = new object();
             lock (lockObject)
             {
                 this.x = x;
                 this.y = y;

             OnPropertyChanged("x");
             OnPropertyChanged("y");
             }
         }*/

        private async Task Move()
        {
            Stopwatch stopwatch = new Stopwatch();

            while (!StopThreads)
            {
                stopwatch.Restart();
                stopwatch.Start();
                _vector.X += (float)XSpeed;
                _vector.Y += (float)YSpeed;
                OnPropertyChanged("Vector");
                stopwatch.Stop();
                int sleepTime = (int)(stopwatch.Elapsed.TotalMilliseconds);
                await Task.Delay(sleepTime);
            }
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