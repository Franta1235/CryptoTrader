using System.Collections.Generic;

namespace CryptoTrader.Helper.Candle
{
    public class IncompleteCandle : ICandle
    {
        private readonly LinkedList<Price> _prices;
        private readonly CandleInterval _candleInterval;
        private int _openTimeStamp;

        public IncompleteCandle(CandleInterval candleInterval) {
            _prices = new LinkedList<Price>();
            _candleInterval = candleInterval;
        }

        public void Advance(Price price) {
            _openTimeStamp = price.TimeStamp - price.TimeStamp % (int)_candleInterval;
            _prices.AddFirst(price);
            while (_prices.Last.Value.TimeStamp < _openTimeStamp) {
                _prices.RemoveLast();
            }
        }

        public int GetOpenTimeStamp() {
            return _openTimeStamp;
        }

        public int GetCloseTimeStamp() {
            return _openTimeStamp + (int)_candleInterval;
        }

        public Price GetOpenPrice() {
            return _prices.Last.Value;
        }

        public Price GetClosePrice() {
            return _prices.First.Value;
        }

        public double GetSigma() {
            throw new System.NotImplementedException();
        }

        public LinkedList<Price> GetPrices() {
            return _prices;
        }
    }
}