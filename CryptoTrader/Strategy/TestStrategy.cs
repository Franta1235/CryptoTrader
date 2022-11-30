using System;
using CryptoTrader.Helper;
using CryptoTrader.Helper.Candle;

namespace CryptoTrader.Strategy
{
    public class TestStrategy : IStrategy
    {
        private readonly HistoryAnalyzer.HistoryAnalyzer _historyAnalyzer;

        public TestStrategy() {
            _historyAnalyzer = new HistoryAnalyzer.HistoryAnalyzer(200, CandleInterval.CandleInterval60);
        }

        public double Advance(Price price) {
            _historyAnalyzer.Advance(price);
            return 0;
        }
    }
}