using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Tests
{
    [TestClass()]
    public class CircleTest
    {
        [TestMethod]
        public void CircleTests()
        {
            Ball ball = new Ball(1, 2, 3);

            Circle circle = new Circle(ball);

            Assert.AreEqual(ball.x, circle.x);
            Assert.AreEqual(ball.y, circle.y);
            Assert.AreEqual(ball.radius, circle.radius);
        }
    }
}
