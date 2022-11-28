using CryptoTrader.Helper;

namespace CryptoTrader.Runner
{
    public class BinanceRunner : ARunner
    {
        public override Price NewPrice() {
            throw new System.NotImplementedException();
        }

        public override void MakeOrderBuy(Price price, double order) {
            throw new System.NotImplementedException();
        }

        public override void MakeOrderSell(Price price, double order) {
            throw new System.NotImplementedException();
        }
    }
}