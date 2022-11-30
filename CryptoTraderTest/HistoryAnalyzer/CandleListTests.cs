using System.Linq;
using CryptoTrader.Helper;
using CryptoTrader.Helper.Candle;
using CryptoTrader.HistoryAnalyzer;
using NUnit.Framework;

namespace CryptoTraderTest.HistoryAnalyzer
{
    [TestFixture]
    public class CandleListTests
    {
        [Test]
        public void Test1() {
            var candleList = new CandleList(3);
            for (var i = 0; i < 10; i++) {
                var price = new Price(0, 0, i);
                candleList.Add(new EmptyCandle(price, i, i + 1));
            }

            Assert.AreEqual(3, candleList.GetCandles().Count);
            Assert.AreEqual(9, candleList[0].GetOpenTimestamp());
            Assert.AreEqual(8, candleList[1].GetOpenTimestamp());
            Assert.AreEqual(7, candleList[2].GetOpenTimestamp());
        }
    }
}