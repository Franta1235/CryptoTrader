using CryptoTrader.DataInterface;
using NUnit.Framework;

namespace CryptoTraderTest.DataInterface
{
    [TestFixture]
    public class PostgreSqlInterfaceTests
    {
        [Test]
        public void TestGetCandles1() {
            PostgreSqlInterface.GetPrices();
        }
    }
}