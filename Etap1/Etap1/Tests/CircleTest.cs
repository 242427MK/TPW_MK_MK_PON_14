﻿using Etap1.Presentation.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Etap1.Logic;
using Etap1.Presentation.Model;

namespace Etap1.Tests
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