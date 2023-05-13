using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
        public class ViewModelApi : INotifyPropertyChanged
        {
            private bool isGenerating = false;

            public bool IsGenerating
            {
                get { return isGenerating; }
            }


        AbstractModelApi modelAPI = AbstractModelApi.instance;
            AbstractLogicApi logicAPI = AbstractLogicApi.instance;

            public ViewModelApi()
            {
                this.SignalStart = new Signal(Start);
                this.SignalStop = new Signal(Stop);
            }

            public string BallQuantity
            {
                get;
                set;
            }

            private ObservableCollection<Circle> CircleCollection;

            public ObservableCollection<Circle> circleCollection
            {
                get { return CircleCollection; }
                set
                {
                    CircleCollection = value;
                    OnPropertyChanged("CircleCollection");
                }
            }

            public ICommand SignalStart
            {
                get;
                set;
            }

            public ICommand SignalStop
            {
                get;
                set;
            }

            public void Start()
            {
                if (isGenerating) return;
                isGenerating = true;

                logicAPI.GenerateRandomBalls(Convert.ToInt32(BallQuantity));
                modelAPI.BallsToCircles();
                CircleCollection = modelAPI.GetCircles();
                foreach (Circle circle in CircleCollection)
                {
                    circle.PropertyChanged += propertyChanged;
                }
                logicAPI.CreateThreads();
        }

            public void Stop()
            {
                isGenerating = false;
                logicAPI.Stopthreads();
            }

            private void propertyChanged(object sender, PropertyChangedEventArgs e)
            {
                OnPropertyChanged("CircleCollection");
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

