namespace CryptoTrader.Helper.Candle
{
    public class EmptyCandle : ICandle
    {
        private readonly Price _price;
        private readonly double _openTimestamp;
        private readonly double _closeTimestamp;

        public EmptyCandle(Price price, double openTimestamp, double closeTimestamp) {
            _price = price;
            _openTimestamp = openTimestamp;
            _closeTimestamp = closeTimestamp;
        }

        public double GetOpenTimestamp() {
            return _openTimestamp;
        }

        public double GetCloseTimestamp() {
            return _closeTimestamp;
        }

        public Price GetOpenPrice() {
            return new Price(_price.BestBid, _price.BestAsk, _openTimestamp);
        }

        public Price GetClosePrice() {
            return new Price(_price.BestBid, _price.BestAsk, _closeTimestamp);
        }

        public double GetSigma() {
            return 0;
        }

        public override string ToString() {
            return $"Empty Candle: {_openTimestamp} - {_closeTimestamp}";
        }
    }
}