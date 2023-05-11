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
            double x = 10;
            double y = 10;
            double r = 10;
            double w = 10;


            Orb orb = new Orb(x, y, r, w);

            Circle circle = new Circle(orb);

            Assert.AreEqual(circle.x, x);
            Assert.AreEqual(circle.y, y);
            Assert.AreEqual(circle.radius, r);

            int x2 = 40;
            int y2 = 50;
            int r2 = 60;

            circle.x = x2;
            circle.y = y2;
            circle.radius = r2;

            Assert.AreEqual(circle.x, x2);
            Assert.AreEqual(circle.y, y2);
            Assert.AreEqual(circle.radius, r2);
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

