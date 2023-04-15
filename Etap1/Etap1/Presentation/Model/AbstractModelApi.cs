using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Etap1.Logic;

namespace Etap1.Presentation.Model
{
    public abstract class AbstractModelApi
    {
        public static AbstractModelApi CreateApi(AbstractLogicApi abstractLogicApi = null)
        {
            return new ModelApi();
        }
        public abstract void CreateScene(int orbQuantity, int orbRadius);
        public abstract ObservableCollection<Circle> GetAllCircles();
        public abstract void Enable();
        public abstract void Disable();
        public abstract bool IsEnabled();
        public sealed class ModelApi : AbstractModelApi
        {
            private AbstractLogicApi logicApi = AbstractLogicApi.CreateApi(null);
            private ObservableCollection<Circle> circles = new ObservableCollection<Circle>();
            public ObservableCollection<Circle> Circles
            {
                get
                {
                    return circles;
                }
                set
                {
                    circles = value;
                }
            }

            public ModelApi(AbstractLogicApi abstractLogicApi = null)
            {
                if (abstractLogicApi == null)
                {
                    this.logicApi = AbstractLogicApi.CreateApi();
                }
                else
                {
                    this.logicApi = abstractLogicApi;
                }
            }

            public override void CreateScene(int ballQuantity, int ballRadius)
            {
                logicApi.CreateScene(750, 600, ballQuantity, ballRadius);
            }

            public override ObservableCollection<Circle> GetAllCircles()
            {
                List<Ball> balls = logicApi.GetBalls();
                Circles.Clear();
                foreach (Ball ball in balls)
                {
                    Circles.Add(new Circle(ball));
                }
                return Circles;
            }

            public override void Enable()
            {
                logicApi.Enable();
            }

            public override void Disable()
            {
                logicApi.Disable();
            }

            public override bool IsEnabled()
            {
                return logicApi.IsEnabled();
            }
        }
    }
}
