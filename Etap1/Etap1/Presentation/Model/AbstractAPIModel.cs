using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etap1.Presentation.Model
{
    public abstract class Model {

        public static AbstractAPIModel abstractAPIModel(AbstractLogicApi abstractLogicApi = null)
        {
            return new ModelApi();
        }

        public abstract void CreateScene(int ballQuantity, int ballRadius);
        public abstract ObservableCollection<Circle> GetAllCircles();
        public abstract void Enable();
        public abstract void Disable();
        public abstract bool IsEnabled();
        public sealed class ModelApi : AbstractAPIModel

            //zmiany poniżej
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
        }

        public ModelApi (AbstractLogicApi abstractLogicApi = null)
        {
            if( abstractLogicApi = null)
            {
                this.logicApi = abstractLogicApi.CreateApi();
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
            List<Orb> orbs = logicApi.GetOrbs();
            Circles.Clear();
            foreach (Orb orb in orbs)
            {
                Circles.Add(new Circle(orb));
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
