using System;
using CryptoTrader.Helper.Candle;

namespace CryptoTrader.HistoryAnalyzer
{
    public class HistoryAnalyzerFactory
    {
        public static HistoryAnalyzer Create(int timeStamp, string pair, int length, CandleInterval candleInterval) {
            var historyAnalyzer = new HistoryAnalyzer(length, candleInterval);
            // TODO import prices...
            throw new NotImplementedException();
            return historyAnalyzer;
        }
    }
}