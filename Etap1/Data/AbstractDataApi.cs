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

        public abstract List<Orb> GetOrbList();

        public static AbstractDataApi instance
        {
            get { return Instance; }
        }

        internal sealed class DataApi : AbstractDataApi
        {
            internal DataApi() { }

            private List<Orb> OrbList = new List<Orb>();

            public override List<Orb> GetOrbList()
            {
                return OrbList;
            }
        }
    }
}