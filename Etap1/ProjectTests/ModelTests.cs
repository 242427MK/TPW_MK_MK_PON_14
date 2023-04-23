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

namespace ProjectTests
{
    [TestClass()]
    public class ModelTests
    {
        [TestMethod]
        public void CircleTests()
        {
            int x = 10;
            int y = 10;

            Orb orb = new Orb(x, y);
            Ball ball = new Ball(orb);
            Circle circle = new Circle(ball);

            Assert.AreEqual(circle.x, x);
            Assert.AreEqual(circle.y, y);


            int x2 = 40;
            int y2 = 50;

            circle.x = x2;
            circle.y = y2;

            Assert.AreEqual(circle.x, x2);
            Assert.AreEqual(circle.y, y2);
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

