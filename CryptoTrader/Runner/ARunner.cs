using System;
using CryptoTrader.Helper;
using CryptoTrader.Strategy;

namespace CryptoTrader.Runner
{
    public abstract class ARunner : IRunner
    {
        protected double Asset1;
        protected double Asset2;

        public void Run(IStrategy strategy) {
            SetAssets();
            var price = NewPrice();
            while (price != null) {
                var order = strategy.Advance(price);
                if (order > 0) MakeOrderBuy(price, order);
                if (order < 0) MakeOrderSell(price, order);
                price = NewPrice();
            }
        }

        public abstract Price NewPrice();
        public abstract void MakeOrderBuy(Price price, double order);
        public abstract void MakeOrderSell(Price price, double order);
        public abstract void SetAssets();
    }
}