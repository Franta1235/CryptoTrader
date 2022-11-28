namespace CryptoTrader.Helper.Candle
{
    public interface ICandle
    {
        /// <summary>
        /// Get timestamp of theoretical open. Could differs from open price.
        /// </summary>
        /// <returns></returns>
        int GetOpenTimeStamp();

        /// <summary>
        /// Get timestamp of theoretical close. Could differs from close price.
        /// </summary>
        /// <returns></returns>
        int GetCloseTimeStamp();
        
        /// <summary>
        /// First price in candle
        /// </summary>
        /// <returns></returns>
        Price GetOpenPrice();
        
        /// <summary>
        /// Last price in candle
        /// </summary>
        /// <returns></returns>
        Price GetClosePrice();
        
        /// <summary>
        /// Volatility
        /// </summary>
        /// <returns></returns>
        double GetSigma();
    }
}