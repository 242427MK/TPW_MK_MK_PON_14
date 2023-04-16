using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Ball
    {
        private double X;
        private double Y;
        private double Radius;

        public Ball(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
