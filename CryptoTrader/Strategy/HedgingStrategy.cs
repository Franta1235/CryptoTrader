using CryptoTrader.Helper;

namespace CryptoTrader.Strategy
{
    public abstract class HedgingStrategy : IStrategy
    {
        private HistoryAnalyzer.HistoryAnalyzer _historyAnalyzer;

        public double Advance(Price price) {
            throw new System.NotImplementedException();
        }
    }
}