using CryptoTrader.Helper;
using CryptoTrader.Helper.Candle;
using NUnit.Framework;

namespace CryptoTraderTest.Helper.Candle
{
    [TestFixture]
    public class TrailingCandleTests
    {
        [Test]
        public void Test1() {
            var candle = new TrailingCandle(CandleInterval.CandleInterval60);
            for (var i = 0; i < 100; i++) {
                var price = new Price(0, 0, i);
                candle.Advance(price);
            }

            Assert.AreEqual(99, candle.GetClosePrice().Timestamp);
            Assert.AreEqual(39, candle.GetOpenPrice().Timestamp);
        }
        
        [Test]
        public void Test2() {
            var candle = new TrailingCandle(CandleInterval.CandleInterval60);
            for (var i = 0; i < 100; i++) {
                var price = new Price(0, 0, i);
                candle.Advance(price);
            }
            
            for (var i = 120; i < 140; i++) {
                var price = new Price(0, 0, i);
                candle.Advance(price);
            }

            Assert.AreEqual(139, candle.GetClosePrice().Timestamp);
            Assert.AreEqual(79, candle.GetOpenPrice().Timestamp);
        }
        
        [Test]
        public void Test3() {
            var candle = new TrailingCandle(CandleInterval.CandleInterval60);
            for (var i = 0; i < 100; i++) {
                var price = new Price(0, 0, i);
                candle.Advance(price);
            }
            
            for (var i = 180; i < 190; i++) {
                var price = new Price(0, 0, i);
                candle.Advance(price);
            }

            Assert.AreEqual(189, candle.GetClosePrice().Timestamp);
            Assert.AreEqual(180, candle.GetOpenPrice().Timestamp);
        }
        
        [Test]
        public void Test4() {
            var candle = new TrailingCandle(CandleInterval.CandleInterval60);
            for (var i = 0; i < 1000000; i++) {
                var price = new Price(0, 0, i);
                candle.Advance(price);
            }

            Assert.AreEqual(999999, candle.GetClosePrice().Timestamp);
            Assert.AreEqual(999939, candle.GetOpenPrice().Timestamp);
        }
    }
}