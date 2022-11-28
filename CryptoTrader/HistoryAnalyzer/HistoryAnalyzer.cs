using System.Linq;
using CryptoTrader.Helper;
using CryptoTrader.Helper.Candle;

namespace CryptoTrader.HistoryAnalyzer
{
    public class HistoryAnalyzer : IHistoryAnalyzer
    {
        private Price _currentPrice;
        private readonly CandleList _candles;
        private readonly IncompleteCandle _incompleteCandle;
        private readonly CandleInterval _candleInterval;

        public HistoryAnalyzer(int length, CandleInterval candleInterval) {
            _candleInterval = candleInterval;
            _incompleteCandle = new IncompleteCandle(_candleInterval);
            _candles = new CandleList(length);
        }

        public void Advance(Price price) {
            _currentPrice = price;
            var lastOpenTimeStamp = _incompleteCandle.GetOpenTimeStamp();
            var currentTimeStamp = _currentPrice.TimeStamp;
            if (currentTimeStamp - lastOpenTimeStamp >= (int)_candleInterval) {
                AddCandle();
            }

            _incompleteCandle.Advance(price);
        }

        public double PredictVolatility() {
            throw new System.NotImplementedException();
        }

        private void AddCandle() {
            var candle = new Candle(_incompleteCandle, _candleInterval);
            _candles.AddFirst(candle);

            var lastOpenTimeStamp = _incompleteCandle.GetOpenTimeStamp();
            var currentTimeStamp = GetCurrentTimeStamp();
            var missingCandles = (currentTimeStamp - lastOpenTimeStamp) / (int)_candleInterval - 1;
            for (var i = 0; i < missingCandles; i++) {
                var emptyCandle = new EmptyCandle(
                    _incompleteCandle.GetClosePrice(),
                    lastOpenTimeStamp + (i + 1) * (int)_candleInterval,
                    lastOpenTimeStamp + (i + 2) * (int)_candleInterval);
                _candles.AddFirst(emptyCandle);
            }
        }

        private int GetCurrentTimeStamp() {
            return _currentPrice.TimeStamp;
        }

        public override string ToString() {
            return _candles.GetCandles().Aggregate(string.Empty, (current, candle) => current + $"{candle}\n");
        }
    }
}