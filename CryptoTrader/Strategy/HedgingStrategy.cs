using CryptoTrader.Helper;

namespace CryptoTrader.Strategy
{
    public abstract class HedgingStrategy : IStrategy
    {
        protected HistoryAnalyzer.HistoryAnalyzer HistoryAnalyzer;

        public double Advance(Price price) {
            throw new System.NotImplementedException();
        }
    }
}