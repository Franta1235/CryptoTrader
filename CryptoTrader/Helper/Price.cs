namespace CryptoTrader.Helper
{
    public class Price
    {
        public Price(double bestBid, double bestAsk, int timeStamp) {
            BestBid = bestBid;
            BestAsk = bestAsk;
            TimeStamp = timeStamp;
        }

        public double BestBid { get; }
        public double BestAsk { get; }
        public int TimeStamp { get; }

        public override string ToString() {
            return $"Best bid: {BestBid}, Best Ask: {BestAsk}, TimeStamp: {TimeStamp}";
        }
    }
}