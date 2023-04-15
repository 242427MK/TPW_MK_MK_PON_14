using Microsoft.VisualStudio.TestTools.UnitTesting;
using Etap1.Logic;

namespace Etap1.Tests
{
    [TestClass]
    class BallTest
    {
        Ball orb = new Ball(1, 2, 3);

        [TestMethod]
        public void GetterTest()
        {
            Assert.AreEqual(1, orb.x);
            Assert.AreEqual(2, orb.y);
            Assert.AreEqual(3, orb.radius);
        }

        [TestMethod]
        public void SetterTest()
        {
            orb.x = 2;
            orb.y = 4;
            orb.radius = 6;

            Assert.AreEqual(2, orb.x);
            Assert.AreEqual(4, orb.y);
            Assert.AreEqual(6, orb.radius);
        }
    }
}
