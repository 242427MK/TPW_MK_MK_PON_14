using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public abstract class AbstractDataApi
    {
        public abstract int upBorder();

        public abstract int downBorder();

        public abstract int leftBorder();

        public abstract int rightBorder();

        private static DataApi Instance = new DataApi();

        public static AbstractDataApi CreateNewInstance() { return new DataApi(); }

        public abstract List<Orb> GetOrbList();

        public static AbstractDataApi instance
        {
            get { return Instance; }
        }

        internal sealed class DataApi : AbstractDataApi
        {

            public Logger loger;

            private int Up_border = 0;
            private int Down_border = 600;
            private int Left_border = 0;
            private int Right_border = 600;

            public override int upBorder()
            {
                return this.Up_border;
            }

            public override int downBorder()
            {
                return this.Down_border;
            }

            public override int leftBorder()
            {
                return this.Left_border;
            }

            public override int rightBorder()
            {
                return this.Right_border;
            }

            internal DataApi() { }

            private List<Orb> OrbList = new List<Orb>();

            public override List<Orb> GetOrbList()
            {
                return OrbList;
            }
        }
    }
}