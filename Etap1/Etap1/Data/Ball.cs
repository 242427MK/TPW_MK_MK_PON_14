using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Etap1.Data
{
    public class Ball
    {
        private double X;
        private double Y;

        private double Radius;

        private double speedX;
        private double speedY;


        public Ball( double x, double y, double radius ) {

            X = x;
            Y = y;
            Radius = radius;

            Random random = new Random();
            double xSpeed = 0;
            do
            {
                xSpeed = random.NextDouble() * 0.99;
            } while (xSpeed == 0);

            double ySpeed = Math.Sqrt(4 - (xSpeed * xSpeed));
            ySpeed = (random.Next(-1, 1) < 0) ? ySpeed : -ySpeed;


            speedX = xSpeed;
            speedY = ySpeed;
        }

        public double x
        {
            get { return X; }
            set
            {
                X = value;
                OnPropertyChanged("x");
            }
        }

        public double y
        {
            get { return Y; }
            set
            {
               Y = value;
                OnPropertyChanged("y");
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

        public double SpeedX
        {
            get { return speedX; }
            set { speedX = value; }
        }

        public double SpeedY
        {
            get { return speedY; }
            set { speedY = value; }
        }


        public void move()
        {
            this.X += this.speedX;
            this.Y += this.speedY;
            OnPropertyChanged("Position");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
