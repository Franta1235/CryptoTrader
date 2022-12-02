using System;
using CryptoTrader.Helper;
using CryptoTrader.Helper.Candle;
using CryptoTrader.HistoryAnalyzer;

namespace CryptoTrader.Strategy.HedgingStrategy
{
    public abstract class AHedgingStrategy : IStrategy
    {
        protected IHistoryAnalyzer HistoryAnalyzer;
        protected CandleInterval _candleInterval;
        protected Price CurrentPrice;
        protected Price OpenPrice;
        protected double LastOpenTimestamp;


        public AHedgingStrategy(IHistoryAnalyzer historyAnalyzer, CandleInterval candleInterval) {
            HistoryAnalyzer = historyAnalyzer;
            _candleInterval = candleInterval;
        }

        public double Advance(Price price) {
            CurrentPrice = price;
            HistoryAnalyzer.Advance(price);
            if (IsNewContract()) StartNewContract();
            return MakeOrder();
        }

        private bool IsNewContract() {
            var openTimestamp = CurrentPrice.Timestamp - CurrentPrice.Timestamp % (int) _candleInterval;
            return Math.Abs(openTimestamp - LastOpenTimestamp) > 1;
        }

        protected abstract double MakeOrder();

        protected abstract void StartNewContract();

        protected abstract double GetPosition();

        protected abstract double ContractPrice();
    }
}