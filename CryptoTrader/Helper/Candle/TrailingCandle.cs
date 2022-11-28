using System.Collections.Generic;

namespace CryptoTrader.Helper.Candle
{
    public class TrailingCandle : ICandle
    {
        private readonly LinkedList<Price> _prices;
        private readonly CandleInterval _candleInterval;

        public TrailingCandle(CandleInterval candleInterval) {
            _prices = new LinkedList<Price>();
            _candleInterval = candleInterval;
        }

        public void Advance(Price price) {
            _prices.AddFirst(price);
            while (price.TimeStamp - _prices.Last.Value.TimeStamp > (int)_candleInterval) {
                _prices.RemoveLast();
            }
        }

        public int GetOpenTimeStamp() {
            throw new System.NotImplementedException();
        }

        public int GetCloseTimeStamp() {
            throw new System.NotImplementedException();
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
    }
}