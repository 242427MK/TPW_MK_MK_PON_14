using Data;
using Logic;

namespace LogicTests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod]
        public void LogicApiTest()
        {

            AbstractDataApi DataApi = AbstractDataApi.CreateNewInstance();
            AbstractLogicApi LogicApi = AbstractLogicApi.CreateNewInstance(DataApi);

            Assert.IsNotNull(LogicApi);

            int iloscKulek = 10;

            LogicApi.GenerateRandomBalls(iloscKulek);
            List<Ball> balls = LogicApi.GetBallList();

            Assert.AreEqual(balls.Count, iloscKulek);
        }
    }
}
