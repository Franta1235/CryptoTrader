using CryptoTrader.Helper.Python;
using NUnit.Framework;

namespace CryptoTraderTest.Helper.Python
{
    [TestFixture]
    public class PythonScriptRunnerTests
    {
        [Test]
        public void Test1() {
            var result = PythonScriptRunner.RunJson(
                @"C:\Users\fkoznar\RiderProjects\CryptoTrader\CryptoTraderTest\Helper\Python\TestScripts\TestScript1.py",
                5.ToString());
            Assert.AreEqual(25.ToString(), result);
        }

        [Test]
        public void Test2() {
            for (var i = 0; i < 10; i++) {
                var result = PythonScriptRunner.RunJson(
                    @"C:\Users\fkoznar\RiderProjects\CryptoTrader\CryptoTraderTest\Helper\Python\TestScripts\TestScript1.py",
                    i.ToString());
                Assert.AreEqual((i * i).ToString(), result);
            }
        }
    }
}