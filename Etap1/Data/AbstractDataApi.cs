using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public abstract class AbstractDataApi
    {
        private static DataApi Instance = new DataApi();

        public static AbstractDataApi CreateNewInstance() { return new DataApi(); }

        public abstract List<Ball> GetBallList();

        public static AbstractDataApi instance
        {
            get { return Instance; }
        }

        internal sealed class DataApi : AbstractDataApi
        {
            internal DataApi() { }

            private List<Ball> BallList = new List<Ball>();

            public override List<Ball> GetBallList()
            {
                return BallList;
            }
        }
    }
}