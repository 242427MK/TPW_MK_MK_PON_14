using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BallLogic
    {
        private Ball ball;

        public BallLogic(Ball ball1)
        {
            ball = ball1;
            ball.PropertyChanged += Update;
        }

        public double x
        {
            get { return ball.x; }
            set
            {
                ball.x = value;
                OnPropertyChanged("x");
            }
        }
        public double y
        {
            get { return ball.y; }
            set
            {
                ball.y = value;
                OnPropertyChanged("y");
            }
        }
        public double radius
        {
            get { return ball.radius; }
            set
            {
                ball.radius = value;
                OnPropertyChanged("radius");
            }
        }

        private void Update(object source, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "xp")
            {
                OnPropertyChanged("x");
            }
            else if (e.PropertyName == "y")
            {
                OnPropertyChanged("y");
            }
            else if (e.PropertyName == "radius")
            {
                OnPropertyChanged("radius");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

