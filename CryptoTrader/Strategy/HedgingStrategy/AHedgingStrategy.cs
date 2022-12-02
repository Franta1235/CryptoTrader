using System;
using CryptoTrader.Helper;
using CryptoTrader.HistoryAnalyzer;

namespace CryptoTrader.Strategy.HedgingStrategy
{
    public abstract class AHedgingStrategy : IStrategy
    {
        protected IHistoryAnalyzer HistoryAnalyzer;
        protected Price CurrentPrice;


        public AHedgingStrategy(IHistoryAnalyzer historyAnalyzer) {
            HistoryAnalyzer = historyAnalyzer;
        }

        public double Advance(Price price) {
            CurrentPrice = price;
            HistoryAnalyzer.Advance(price);
            return Recalculate();
        }

        protected abstract double Recalculate();

        protected abstract double GetPosition();
    }
}