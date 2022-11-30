using System.Collections.Generic;
using System.Linq;

namespace CryptoTrader.Helper.Candle
{
    public class FillingCandle : ICandle
    {
        private LinkedList<Price> _prices;
        private readonly CandleInterval _candleInterval;
        private double _openTimestamp;
        private double _lastOpenTimestamp;

        public FillingCandle(CandleInterval candleInterval) {
            _prices = new LinkedList<Price>();
            _candleInterval = candleInterval;
        }

        /// <summary>
        /// Adds price to list, and if it starts new candle, remove prices before openTimestamp
        /// </summary>
        /// <param name="price"></param>
        public void Advance(Price price) {
            _openTimestamp = price.Timestamp - price.Timestamp % (int)_candleInterval;
            _prices.AddFirst(price);

            if (_lastOpenTimestamp < _openTimestamp) {
                // TODO Can be done maybe little bit faster, with pointers...
                _prices = new LinkedList<Price>();
                _prices.AddFirst(price);
            }

            _lastOpenTimestamp = _openTimestamp;
        }

        public double GetOpenTimestamp() {
            return _openTimestamp;
        }

        public double GetCloseTimestamp() {
            return _openTimestamp + (int)_candleInterval;
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