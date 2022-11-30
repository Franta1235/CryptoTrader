using CryptoTrader.Helper;
using CryptoTrader.Helper.Candle;
using NUnit.Framework;

namespace CryptoTraderTest.Helper.Candle
{
    [TestFixture]
    public class IncompleteCandleTests
    {
        [Test]
        public void Test1() {
            var candle = new FillingCandle(CandleInterval.CandleInterval60);
            for (var i = 0; i < 10; i++) {
                var price = new Price(0, 0, i);
                candle.Advance(price);
            }

            Assert.AreEqual(0, candle.GetOpenPrice().Timestamp);
            Assert.AreEqual(9, candle.GetClosePrice().Timestamp);
        }

        [Test]
        public void Test2() {
            var candle = new FillingCandle(CandleInterval.CandleInterval60);
            for (var i = 0; i < 70; i++) {
                var price = new Price(0, 0, i);
                candle.Advance(price);
            }

            Assert.AreEqual(60, candle.GetOpenPrice().Timestamp);
            Assert.AreEqual(69, candle.GetClosePrice().Timestamp);
        }

        [Test]
        public void Test3() {
            var candle = new FillingCandle(CandleInterval.CandleInterval60);
            for (var i = 0; i < 120; i++) {
                var price = new Price(0, 0, i);
                candle.Advance(price);
            }

            Assert.AreEqual(60, candle.GetOpenPrice().Timestamp);
            Assert.AreEqual(119, candle.GetClosePrice().Timestamp);
        }

        //[Test]
        public void TestPerformance() {
            var candle = new FillingCandle(CandleInterval.CandleInterval86400);
            for (double timestamp = 0; timestamp < 86400.0 * 100000.0; timestamp += 60) {
                var price = new Price(0, 0, timestamp);
                candle.Advance(price);
            }

            Assert.IsTrue(true);
        }
    }
}