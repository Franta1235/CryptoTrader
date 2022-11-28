using System;
using CryptoTrader.Helper;
using CryptoTrader.Helper.Candle;
using NUnit.Framework;

namespace CryptoTraderTest.HistoryAnalyzer
{
    [TestFixture]
    public class HistoryAnalyzerTests
    {
        [Test]
        public void Test1() {
            var historyAnalyzer = new CryptoTrader.HistoryAnalyzer.HistoryAnalyzer(3, CandleInterval.CandleInterval60);
            for (var i = 0; i < 240; i++) {
                var price = new Price(1, 1, i);
                historyAnalyzer.Advance(price);
            }

            Assert.AreEqual("Candle: 120 - 180\nCandle: 60 - 120\nCandle: 0 - 60\n", historyAnalyzer.ToString());
        }

        [Test]
        public void Test2() {
            var historyAnalyzer = new CryptoTrader.HistoryAnalyzer.HistoryAnalyzer(3, CandleInterval.CandleInterval60);
            var price = new Price(1, 1, 5);
            historyAnalyzer.Advance(price);

            for (var i = 120; i < 240; i++) {
                price = new Price(1, 1, i);
                historyAnalyzer.Advance(price);
            }

            Assert.AreEqual("Candle: 120 - 180\nEmpty Candle: 60 - 120\nCandle: 0 - 60\n", historyAnalyzer.ToString());
            Console.WriteLine(historyAnalyzer.ToString());
        }

        [Test]
        public void Test3() {
            var historyAnalyzer =
                new CryptoTrader.HistoryAnalyzer.HistoryAnalyzer(200, CandleInterval.CandleInterval60);
            for (var i = 0; i < 1000000; i++) {
                var price = new Price(1, 1, i);
                historyAnalyzer.Advance(price);
            }

            //Console.WriteLine(historyAnalyzer.ToString());
        }
    }
}