using System;
using CryptoTrader.Helper;
using CryptoTrader.Strategy;

namespace CryptoTrader.Runner
{
    public abstract class ARunner : IRunner
    {
        public void Run(IStrategy strategy) {
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
    }
}