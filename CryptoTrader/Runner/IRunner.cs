using CryptoTrader.Strategy;

namespace CryptoTrader.Runner
{
    public interface IRunner
    {
        void Run(IStrategy strategy);
    }
}