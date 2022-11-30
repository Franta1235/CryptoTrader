namespace CryptoTrader.Helper
{
    public class Price
    {
        public Price(double bestBid, double bestAsk, double timestamp) {
            BestBid = bestBid;
            BestAsk = bestAsk;
            Timestamp = timestamp;
        }

        /// <summary>
        /// Best bid on market
        /// </summary>
        public double BestBid { get; }

        /// <summary>
        /// Best ask on market
        /// </summary>
        public double BestAsk { get; }

        /// <summary>
        /// Timestamp of the price
        /// </summary>
        public double Timestamp { get; }

        public override string ToString() {
            return $"Best bid: {BestBid}, Best Ask: {BestAsk}, TimeStamp: {Timestamp}";
        }
    }
}