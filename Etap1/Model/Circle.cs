
using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using Data;

namespace Model
{
    public class Circle : INotifyPropertyChanged
    {

        public Circle(Orb orb)
        {
            orb.PropertyChanged += propertyChanged;
            this.x = orb.x;
            this.y = orb.y;
            this.radius = orb.radius;
        }

        private Vector2 _vector;

       // private double X;
 
       // private double Y;
        private double Radius;
        private double Weight;

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

        public double radius
        {
            get { return Radius; }
            set
            {
                Radius = value;
                OnPropertyChanged("radius");
            }
        }

        private void propertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Orb orb = (Orb)sender;
            if (e.PropertyName == "x")
            {
                this.x = orb.x;
            }
            if (e.PropertyName == "y")
            {
                this.y = orb.y;
            }
            if ( e.PropertyName == "radius")
            {
                this.Radius = orb.radius;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
