namespace CryptoTrader.Helper.Candle
{
    public interface ICandle
    {
        /// <summary>
        /// Get timestamp of theoretical open. Could differs from open price.
        /// </summary>
        /// <returns></returns>
        double GetOpenTimestamp();

        /// <summary>
        /// Get timestamp of theoretical close. Could differs from close price.
        /// </summary>
        /// <returns></returns>
        double GetCloseTimestamp();

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
        /// Return estimated volatility for candle
        /// </summary>
        /// <returns></returns>
        double GetSigma();
    }
}