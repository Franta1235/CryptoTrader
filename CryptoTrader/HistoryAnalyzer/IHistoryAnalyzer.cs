using CryptoTrader.Helper;

namespace CryptoTrader.HistoryAnalyzer
{
    public interface IHistoryAnalyzer
    {
        /// <summary>
        /// Advance new price to analyzer
        /// </summary>
        /// <param name="price"></param>
        void Advance(Price price);
        
        /// <summary>
        /// Predict volatility for next candle based on history
        /// </summary>
        /// <returns></returns>
        double PredictVolatility();
    }
}