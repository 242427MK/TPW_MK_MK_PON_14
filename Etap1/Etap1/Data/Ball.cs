using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etap1.Data
{
    public class Ball
    {
        private double X;
        private double Y;
        private double Radius;

        public Ball( double x, double y, double radius ) {
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
            }
        }

        public double y
        {
            get { return Y; }
            set
            {
               Y = value;
            }
        }

        public double radius
        {
            get { return Radius; }
            set
            {
                Radius = value;
            }
        }


    }
}
