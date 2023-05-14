using Data;
namespace DataSss
{
    [TestClass]
    public class DataTests
    {
        Orb orb1 = new Orb(4, 5, 6, 7);
        Orb orb2 = new Orb(4, 5, 6, 7);
        List<Orb> OrbList = new List<Orb>();


        [TestMethod]
        public void OrbTest()
        {
            Assert.AreEqual(orb1.x, 4);
            Assert.AreEqual(orb1.x, orb2.x);

            Assert.AreEqual(orb1.y, 5);
            Assert.AreEqual(orb1.y, orb2.y);

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