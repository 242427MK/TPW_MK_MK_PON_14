using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;
using Model;

namespace ModelTests
{
    [TestClass()]
    public class ModelTests
    {
        [TestMethod]
        public void CircleTests()
        {
            float x = 10;
            float y = 10;
            float r = 10;
            float w = 10;

            Orb orb = new Orb(x, y, r, w);
            Circle circle = new Circle(orb);

            int expectedValue = 10;
            int buffer = 5;


            Assert.AreEqual(circle.radius, r);

            if (circle.x >= expectedValue - buffer && circle.x <= expectedValue + buffer)
            { Assert.IsTrue(true); }
            else
            { Assert.IsTrue(false); }


            if (circle.y >= expectedValue - buffer && circle.y <= expectedValue + buffer)
            { Assert.IsTrue(true); }
            else
            { Assert.IsTrue(false); }

        }
            

        [TestMethod]
        public void ModelApiTests()
        {
            AbstractDataApi DataApi = AbstractDataApi.CreateNewInstance();
            AbstractLogicApi LogicApi = AbstractLogicApi.CreateNewInstance(DataApi);
            AbstractModelApi ModelApi = AbstractModelApi.CreateNewInstance(LogicApi);
            Assert.IsNotNull(ModelApi);

            int ballquantity = 10;

            LogicApi.GenerateRandomBalls(ballquantity);
            ModelApi.BallsToCircles();
            ObservableCollection<Circle> CircleCollection = ModelApi.GetCircles();

            Assert.AreEqual(CircleCollection.Count, ballquantity);
        }
    }
}

