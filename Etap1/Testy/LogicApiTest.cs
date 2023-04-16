using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class LogicApiTest
    {
        [TestMethod]
        public void GeneralLogicApiTest()
        {
            AbstractLogicApi api = AbstractLogicApi.CreateApi();
            api.CreateScene(600, 300, 3, 5);

            Assert.AreEqual(3, api.GetBalls().Count);
            Assert.AreEqual(5, api.GetBalls()[0].radius);

            Assert.IsFalse(api.IsEnabled());

            api.Enable();
            Assert.IsTrue(api.IsEnabled());

            api.Disable();
            Assert.IsFalse(api.IsEnabled());
        }

    }
}
