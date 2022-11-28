using CryptoTrader.Helper;

namespace CryptoTrader.Strategy
{
    public interface IStrategy
    {
        double Advance(Price price);
    }
}