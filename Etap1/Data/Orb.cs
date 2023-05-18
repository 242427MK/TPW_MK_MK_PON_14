using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Orb : INotifyPropertyChanged
    {
        private double X;
        private double Y;
        private double Radius;
        private double Weight;
        private double[] speed = new double[2];
        private double speedVector;

        private bool StopThreads = false;

        public Orb(double x, double y, double radius, double weight)
        {
            setXY(x, y);
            this.Radius = radius;
            this.Weight = weight;

            Random random = new Random();
            double xSpeed = 0;
            do
            {
                xSpeed = random.NextDouble() * 0.99;
            } while (xSpeed == 0);
            double ySpeed = Math.Sqrt(4 - (xSpeed * xSpeed));
            ySpeed = (random.Next(-1, 1) < 0) ? ySpeed : -ySpeed;
            this.speed[0] = xSpeed;
            this.speed[1] = ySpeed;

            this.speedVector = Math.Sqrt((this.XSpeed * this.XSpeed) + (this.YSpeed * this.YSpeed));

            Thread watek = new Thread(() =>
            {
                while (!StopThreads)
                {
                    move();
                    updateSpeedVector();
                    int sleepTime = (int)(15.0 / speedVector);
                    sleepTime++;
                    Thread.Sleep(sleepTime);
                }
            });
            watek.Start();
        }


        public double SpeedVector()
        {
             return this.speedVector; 

        }

        public void updateSpeedVector()
        {
          this.speedVector  = Math.Sqrt((this.XSpeed * this.XSpeed) + (this.YSpeed * this.YSpeed));
        }

        public void stop()
        {
            this.StopThreads = true;
        }

        //zmienić OnPropertyChanged();
        public double x
        {
            get { return this.X; }
            set
            {
                this.X = value;
                OnPropertyChanged("x");
            }

        }

        public double y
        {
            get { return this.Y; }
            set
            {
                this.Y = value;
                OnPropertyChanged("y");
            }
        }

        private void setXY(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        private void move()
        {
            setXY(this.x + this.XSpeed, this.y + this.YSpeed);
        }

        public double radius
        {
            get { return Radius; }
            set
            {
                Radius = value;
                OnPropertyChanged(nameof(radius));
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

