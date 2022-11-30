using System;
using System.Diagnostics.CodeAnalysis;
using CryptoTrader.Helper;
using CryptoTrader.Helper.Candle;
using CryptoTrader.Runner;
using CryptoTrader.Strategy;

namespace CryptoTrader
{
    internal class Program
    {
        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        public static void Main(string[] args) {
            var runner = new HistoryRunner("BTCETH");
            var strategy = new TestStrategy();
            runner.Run(strategy);
        }
    }
}