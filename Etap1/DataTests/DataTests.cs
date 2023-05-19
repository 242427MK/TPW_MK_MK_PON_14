using Data;
namespace DataSss
{
    [TestClass]
    public class DataTests
    {

        [TestMethod]
        public void OrbTest()
        {
            Orb orb1 = new Orb(4, 5, 6, 7);
            Orb orb2 = new Orb(4, 5, 6, 7);
            List<Orb> OrbList = new List<Orb>();

            int expectedValue = 4;
            int buffer = 2;

            if (orb1.x >= expectedValue - buffer && orb1.x <= expectedValue + buffer)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }

            int expectedValue2 = 5;
            if (orb2.y >= expectedValue2 - buffer && orb2.y <= expectedValue2 + buffer)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }

            Assert.AreEqual(orb1.radius, 6);
            Assert.AreEqual(orb1.radius, orb2.radius);

            Assert.AreEqual(orb1.weight, 7);
            Assert.AreEqual(orb1.weight, orb2.weight);
            

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