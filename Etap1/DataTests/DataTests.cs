using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    [TestClass]
    class DataTests
    {
        Orb orb1 = new Orb(4, 5);
        Orb orb2 = new Orb(4, 5);
        List<Orb> OrbList = new List<Orb>();


        [TestMethod]
        public void OrbTest()
        {
            Assert.AreEqual(orb1.x, 4);
            Assert.AreEqual(orb1.y, 5);
            Assert.AreEqual(orb1.x, orb2.x);
            Assert.AreEqual(orb1.y, orb2.y);

            OrbList.Add(orb1);
            OrbList.Add(orb2);

            Assert.AreEqual(OrbList.Count, 2);
        }

        [TestMethod]
        public void AbstractDataApiTest()
        {
            AbstractDataApi DataApi = AbstractDataApi.CreateNewInstance();

            Assert.IsNotNull(DataApi);

            List<Orb> OrbList;
            OrbList = DataApi.GetOrbList();

            Assert.IsNotNull(OrbList);
        }


    }
}
