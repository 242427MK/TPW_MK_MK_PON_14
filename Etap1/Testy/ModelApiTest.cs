using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Tests
{
    [TestClass()]
    public class ModelApiTest
    {
        [TestMethod()]
        public void GeneralModelApiTest()
        {
            AbstractLogicApi logicApi = AbstractLogicApi.CreateApi();
            AbstractModelApi modelApi = AbstractModelApi.CreateApi(logicApi);

            modelApi.CreateScene(5, 5);

            ObservableCollection<Circle> collection = modelApi.GetAllCircles();
            Assert.IsNotNull(collection);

            Assert.AreEqual(10, collection.Count);
            foreach (Circle cc in collection)
            {
                Assert.AreEqual(5, cc.radius);
            }

            Assert.IsFalse(modelApi.IsEnabled());

            modelApi.Enable();
            Assert.IsTrue(modelApi.IsEnabled());

            modelApi.Disable();
            Assert.IsFalse(modelApi.IsEnabled());
        }
    }
}
