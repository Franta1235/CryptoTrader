namespace CryptoTrader.Helper.Candle
{
    public class EmptyCandle : ICandle
    {
        private readonly Price _price;
        private readonly int _openTimeStamp;
        private readonly int _closeTimeStamp;

        public EmptyCandle(Price price, int openTimeStamp, int closeTimeStamp) {
            _price = price;
            _openTimeStamp = openTimeStamp;
            _closeTimeStamp = closeTimeStamp;
        }

        public int GetOpenTimeStamp() {
            return _openTimeStamp;
        }

        public int GetCloseTimeStamp() {
            return _closeTimeStamp;
        }

        public Price GetOpenPrice() {
            return new Price(_price.BestBid, _price.BestAsk, _openTimeStamp);
        }

        public Price GetClosePrice() {
            return new Price(_price.BestBid, _price.BestAsk, _closeTimeStamp);
        }

        public double GetSigma() {
            return 0;
        }

        public override string ToString() {
            return $"Empty Candle: {_openTimeStamp} - {_closeTimeStamp}";
        }
    }
}