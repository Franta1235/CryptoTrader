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

        /// <summary>
        /// Adds new price and remove prices older than candle interval
        /// </summary>
        /// <param name="price"></param>
        public void Advance(Price price) {
            _prices.AddFirst(price);
            while (price.Timestamp - _prices.Last.Value.Timestamp > (int)_candleInterval) {
                _prices.RemoveLast();
            }
        }

        public double GetOpenTimestamp() {
            throw new System.NotImplementedException();
        }

        public double GetCloseTimestamp() {
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