using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public abstract class AbstractDataApi
    {
        public abstract void CreateScene(int width, int height, int ballQuantity, int ballRadius);
        public abstract List<Ball> GetBalls();

        public abstract void Disable();

        public abstract Scene Scene { get; }
        public static AbstractDataApi CreateApi()
        {
            return new DataApi();
        }
    }
}