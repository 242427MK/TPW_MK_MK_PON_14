using Logika;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Etap1.Presentation.Model
{
    public class Circle : INotifyPropertyChanged
    {
        private int x;
        private int y;
        private int radius;
    }

    public Circle(Ball ball)
    {
        this.x = ball.X;
        this.y = ball.Y;
        this.radius = ball.Radius;
        ball.PropertyChanged += Update;
    }

    private void Update(object source, PropertyChangedEventArgs key)
    {
        Ball sourceBall = (Ball)source;
        if (key.PropertyName == "X")
        {
            this.x = sourceBall.X - sourceBall.Radius;
        }
        if (key.PropertyName == "Y")
        {
            this.y = sourceBall.Y - sourceBall.Radius;
        }
        if (key.PropertyName == "Radius")
        {
            this.radius = sourceBall.Radius;
        }

         public int X
    {
        get { return x; }
        set
        {
            x = value;
            OnPropertyChanged("X");
        }
    }

    public int Y
    {
        get { return y; }
        set
        {
            y = value;
            OnPropertyChanged("Y");
        }
    }

    public int Radius
    {
        get { return radius; }
        set
        {
            radius = value;
            OnPropertyChanged("Radius");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
