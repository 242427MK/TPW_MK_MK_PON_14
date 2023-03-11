
namespace Test_przykładowego_programu_etapu_0
{
    using Przykładowy_program_dla_etapu_0;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Calculator calc = new Calculator();

            Assert.AreEqual(3, calc.add(1, 2));

            Assert.AreEqual(7, calc.add(4, 3));
        }
    }
}