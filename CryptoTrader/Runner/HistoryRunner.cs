using System;
using System.Collections.Generic;
using CryptoTrader.Helper;

namespace CryptoTrader.Runner
{
    public class HistoryRunner : ARunner
    {
        private readonly LinkedList<Price> _prices;
        private LinkedListNode<Price> _currentNone;
        private const double Fee = 0.0015;

        public HistoryRunner(string pair) {
            _prices = GetPrices(pair);
            _currentNone = _prices.First;
        }

        public override Price NewPrice() {
            if (_currentNone == null) {
                _currentNone = _prices.First; // So we can run again
                return null;
            }

            var price = _currentNone.Value;
            _currentNone = _currentNone.Next;
            return price;
        }

        public override void MakeOrderBuy(Price price, double order) {
            /*
             * Example:
             * Asset1 ~ USD
             * Asset2 ~ BTC
             */

            // TODO how exactly fees works?
            Asset1 -= order * price.BestAsk;
            Asset2 += order * (1 - Fee);
        }

        public override void MakeOrderSell(Price price, double order) {
            Asset1 += order * price.BestBid * (1 - Fee);
            Asset2 -= order;
        }

        public override void SetAssets() {
            Asset1 = 1;
            Asset2 = 0;
        }

        private static LinkedList<Price> GetPrices(string pair) {
            var list = new LinkedList<Price>();
            var random = new Random();

            for (var timeStamp = 0; timeStamp < 60000000; timeStamp += 60) {
                var price = new Price(random.NextDouble(), random.NextDouble(), timeStamp);
                list.AddLast(price);
            }

            return list;
        }
    }
}