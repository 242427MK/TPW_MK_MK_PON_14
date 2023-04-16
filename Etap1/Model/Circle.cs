
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Logic;
 
namespace Model
{
    public class Circle : INotifyPropertyChanged
    {
        private double X;
        private double Y;
        private double Radius;

        public Circle(Ball ball)
        {
            this.X = ball.x;
            this.Y = ball.y;
            this.Radius = ball.radius;
            ball.PropertyChanged += Update;
        }

        private void Update(object source, PropertyChangedEventArgs key)
        {
            Ball sourceBall = (Ball)source;
            if (key.PropertyName == "x")
            {
                this.X = sourceBall.x - sourceBall.radius;
            }
            if (key.PropertyName == "y")
            {
                this.Y = sourceBall.y - sourceBall.radius;
            }
            if (key.PropertyName == "radius")
            {
                this.Radius = sourceBall.radius;
            }
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
