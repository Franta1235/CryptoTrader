using System.Linq;
using CryptoTrader.Helper;
using CryptoTrader.Helper.Candle;

namespace CryptoTrader.HistoryAnalyzer
{
    public class HistoryAnalyzer : IHistoryAnalyzer
    {
        private Price _currentPrice;
        private readonly CandleList _candles;
        private readonly FillingCandle _fillingCandle;
        private readonly CandleInterval _candleInterval;

        public HistoryAnalyzer(int length, CandleInterval candleInterval) {
            _candleInterval = candleInterval;
            _fillingCandle = new FillingCandle(_candleInterval);
            _candles = new CandleList(length);
        }

        public void Advance(Price price) {
            _currentPrice = price;
            var lastOpenTimeStamp = _fillingCandle.GetOpenTimestamp();
            var currentTimeStamp = _currentPrice.Timestamp;
            if (currentTimeStamp - lastOpenTimeStamp >= (int)_candleInterval) {
                AddCandle();
            }

            _fillingCandle.Advance(price);
        }

        public double PredictVolatility() {
            throw new System.NotImplementedException();
        }

        private void AddCandle() {
            var candle = new Candle(_fillingCandle, _candleInterval);
            _candles.Add(candle);

            var lastOpenTimeStamp = _fillingCandle.GetOpenTimestamp();
            var currentTimeStamp = GetCurrentTimestamp();
            var missingCandles = (currentTimeStamp - lastOpenTimeStamp) / (int)_candleInterval - 1;
            for (var i = 0; i < missingCandles; i++) {
                var emptyCandle = new EmptyCandle(
                    _fillingCandle.GetClosePrice(),
                    lastOpenTimeStamp + (i + 1) * (int)_candleInterval,
                    lastOpenTimeStamp + (i + 2) * (int)_candleInterval);
                _candles.Add(emptyCandle);
            }
        }

        private double GetCurrentTimestamp() {
            return _currentPrice.Timestamp;
        }

        public override string ToString() {
            return _candles.GetCandles().Aggregate(string.Empty, (current, candle) => current + $"{candle}\n");
        }

        public bool IsComplete() {
            return _candles.IsComplete();
        }
    }
}