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
            position = new Vector2(orb.x, orb.y);
            this.radius = orb.radius;
        }

        private Vector2 position;
        private float Radius;

        public float x
        {
            get { return position.X; }
            set
            {
                position.X = value;
                OnPropertyChanged("x");
            }
        }

        public float y
        {
            get { return position.Y; }
            set
            {
                position.Y = value;
                OnPropertyChanged("y");
            }
        }

        public float radius
        {
            get { return Radius; }
            set
            {
                Radius = value;
            }
        }

        private void propertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Orb orb = (Orb)sender;
            if (e.PropertyName == "Move")
            {
                this.x = orb.position.X;
                this.y = orb.position.Y;
            }
            if (e.PropertyName == "radius")
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