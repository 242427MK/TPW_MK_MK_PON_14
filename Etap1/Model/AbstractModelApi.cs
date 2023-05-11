using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Data;
using Logic;


namespace Model
{
    public abstract class AbstractModelApi
    {
        private static AbstractModelApi Instance = new ModelApi();

        public static AbstractModelApi CreateNewInstance(AbstractLogicApi logicApi)
        {
            return new ModelApi(logicApi);
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
                logicApi = AbstractLogicApi.instance;
            }

            internal ModelApi(AbstractLogicApi logicApi)
            {
                this.logicApi = logicApi;
            }

            AbstractLogicApi logicApi = AbstractLogicApi.instance;

            ObservableCollection<Circle> CircleCollection = new ObservableCollection<Circle>();

            public override void BallsToCircles()
            {
                List<Orb> OrbList = logicApi.GetOrbList();
                CircleCollection.Clear();
                foreach (Orb orb in OrbList)
                {
                    CircleCollection.Add(new Circle(orb));
                }
            }

            public override ObservableCollection<Circle> GetCircles()
            {
                return CircleCollection;
            }
        }
    }
}
