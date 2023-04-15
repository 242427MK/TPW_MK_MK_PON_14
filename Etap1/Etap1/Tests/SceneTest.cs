using Microsoft.VisualStudio.TestTools.UnitTesting;
using Etap1.Logic;


namespace Etap1.Tests
{

    [TestClass]
    class SceneTest
    {
        Scene scene = new Scene(600, 300);
        [TestMethod]
        public void GetterTest()
        {
            Assert.AreEqual(600, scene.Width);
            Assert.AreEqual(300, scene.Height);

            scene.GenerateBallList(3, 5);

            Assert.AreEqual(3, scene.Balls.Count);
            Assert.AreEqual(5, scene.Balls[0].radius);

            Assert.AreEqual(false, scene.Enabled);
        }

        [TestMethod]
        public void SetterTest()
        {
            scene.Enabled = true;

            Assert.AreEqual(true, scene.Enabled);
        }
    }
}
