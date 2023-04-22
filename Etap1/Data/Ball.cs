﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Ball : INotifyPropertyChanged
    {
        public Ball(int x, int y)
        {
            this.x = x; this.y = y;
        }

        private int X;
        private int Y;

        public int x
        {
            get { return this.X; }
            set
            {
                this.X = value;
                OnPropertyChanged(nameof(x));
            }
        }
        public int y
        {
            get { return this.Y; }
            set
            {
                this.Y = value;
                OnPropertyChanged(nameof(y));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

