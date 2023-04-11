using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    
        public abstract class AbstractDataApi
    {
        public static AbstractDataApi CreateApi()
        {
            return new DataApi();
        }

        internal sealed class DataApi : AbstractDataApi
        {

        }
    }
}

