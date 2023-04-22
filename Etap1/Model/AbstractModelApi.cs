using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Logic;
using Data;

namespace Model
{
    public abstract class AbstractModelApi
    {
        private static AbstractModelApi Instance = new ModelApi();

        public static AbstractModelApi CreateNewInstance(AbstractDataApi dataApi)
        {
            return new ModelApi(dataApi);
        }

        public static AbstractModelApi instance
        {
            get { return Instance; }
        }

        public abstract void BallsToCircles();

        public abstract ObservableCollection<Circle> GetCircles();

        internal sealed class ModelApi : AbstractModelApi
        {
            internal ModelApi()
            {
                dataApi = AbstractDataApi.instance;
            }

            internal ModelApi(AbstractDataApi dataApi)
            {
                this.dataApi = dataApi;
            }

            AbstractDataApi dataApi = AbstractDataApi.instance;

            ObservableCollection<Circle> CircleCollection = new ObservableCollection<Circle>();

            public override void BallsToCircles()
            {
                List<Ball> BallList = dataApi.GetBallList();
                CircleCollection.Clear();
                foreach (Ball ball in BallList)
                {
                    CircleCollection.Add(new Circle(ball));
                }
            }

            public override ObservableCollection<Circle> GetCircles()
            {
                return CircleCollection;
            }
        }
    }
}
