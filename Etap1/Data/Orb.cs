using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public Orb(double x, double y, double radius, double weight)
        {
            this.x = x;
            this.y = y;
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
        }

        

        public double x
        {
            get { return this.X; }
            set
            {
                this.X = value;
                OnPropertyChanged(nameof(x));
            }
        }
        public double y
        {
            get { return this.Y; }
            set
            {
                this.Y = value;
                OnPropertyChanged(nameof(y));
            }
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

        public void move()
        {
            this.X += this.XSpeed;
            this.Y += this.YSpeed;
            OnPropertyChanged("Position");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

