using System;
using System.Diagnostics.CodeAnalysis;
using CryptoTrader.Helper;
using CryptoTrader.Helper.Candle;

namespace CryptoTrader
{
    internal class Program
    {
        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        public static void Main(string[] args) {
            var historyAnalyzer = new CryptoTrader.HistoryAnalyzer.HistoryAnalyzer(3, CandleInterval.CandleInterval60);
            for (var i = 0; i < 1000000; i++) {
                var price = new Price(1, 1, i);
                historyAnalyzer.Advance(price);
            }

            Console.WriteLine(historyAnalyzer.ToString());
        }
    }
}