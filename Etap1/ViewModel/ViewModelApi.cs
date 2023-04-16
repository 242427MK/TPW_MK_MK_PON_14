
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class ViewModelApi : INotifyPropertyChanged
    {
        private AbstractModelApi modelApi/* = AbstractModelApi.CreateApi()*/;
        private int ballQuantity = 1;
        public string BallQuantity
        {
            get
            {
                return Convert.ToString(ballQuantity);
            }
            set
            {
                ballQuantity = Convert.ToInt32(value);
                OnPropertyChanged("BallQuantity");
            }
        }
        private int ballRadius = 25;

        public ICommand EnableSignal
        {
            get;
            set;
        }
        public ICommand DisableSignal
        {
            get;
            set;
        }

        private ObservableCollection<Circle> ballList;
        public ObservableCollection<Circle> BallList
        {
            get { return ballList; }
            set
            {
                if (value.Equals(this.ballList)) return;
                ballList = value;
                OnPropertyChanged("ballList");
            }
        }

        public ViewModelApi() : this(null) { }
        public ViewModelApi(AbstractModelApi modelApi = null)
        {
            EnableSignal = new Signal(enable);
            DisableSignal = new Signal(disable);
            if (modelApi == null)
            {
                this.modelApi = AbstractModelApi.CreateApi();
            }
            else
            {
                this.modelApi = modelApi;
            }
        }

        private bool isEnabled = true;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                OnPropertyChanged("IsEnabled");
                OnPropertyChanged("IsDisabled");
            }
        }
        public bool IsDisabled
        {
            get
            {
                return !isEnabled;
            }
        }

        private void enable()
        {
            modelApi.CreateScene(ballQuantity, ballRadius);
            modelApi.Enable();
            isEnabled = true;
            ballList = modelApi.GetAllCircles();
        }

        private void disable()
        {
            modelApi.Disable();
            IsEnabled = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
