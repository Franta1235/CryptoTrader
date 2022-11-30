using System;
using System.Collections.Generic;
using CryptoTrader.Helper;
using CryptoTrader.Strategy;

namespace CryptoTrader.Runner
{
    public class HistoryRunner : ARunner
    {
        private LinkedList<Price> _prices;
        private LinkedListNode<Price> _currentNone;

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
            throw new System.NotImplementedException();
        }

        public override void MakeOrderSell(Price price, double order) {
            throw new System.NotImplementedException();
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