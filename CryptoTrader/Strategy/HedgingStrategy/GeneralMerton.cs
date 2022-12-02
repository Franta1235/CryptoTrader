using CryptoTrader.Helper.Candle;
using CryptoTrader.HistoryAnalyzer;

namespace CryptoTrader.Strategy.HedgingStrategy
{
    public class GeneralMerton : AHedgingStrategy
    {
        public GeneralMerton(IHistoryAnalyzer historyAnalyzer, CandleInterval candleInterval) : base(historyAnalyzer, candleInterval) {
        }

        protected override double MakeOrder() {
            throw new System.NotImplementedException();
        }

        protected override void StartNewContract() {
            throw new System.NotImplementedException();
        }

        protected override double GetPosition() {
            throw new System.NotImplementedException();
        }

        protected override double ContractPrice() {
            throw new System.NotImplementedException();
        }
    }
}