using System;
using System.Collections.Generic;

namespace CryptoTrader.Helper.Candle
{
    public class Candle : ICandle
    {
        private readonly CandleInterval _candleInterval;
        private readonly Price _openPrice;
        private readonly Price _closePrice;
        private readonly double _sigma;

        public Candle(FillingCandle fillingCandle, CandleInterval candleInterval) {
            var prices = fillingCandle.GetPrices();
            _openPrice = prices.Last.Value;
            _closePrice = prices.First.Value;
            _candleInterval = candleInterval;
            _sigma = EstimateSigma(prices);
        }

        public double GetOpenTimestamp() {
            return _openPrice.Timestamp - _openPrice.Timestamp % (int)_candleInterval;
        }

        public double GetCloseTimestamp() {
            return GetOpenTimestamp() + (int)_candleInterval;
        }

        public Price GetOpenPrice() {
            return _openPrice;
        }

        public Price GetClosePrice() {
            return _closePrice;
        }

        public double GetSigma() {
            return _sigma;
        }

        public override string ToString() {
            return $"Candle: {GetOpenTimestamp()} - {GetCloseTimestamp()}";
        }

        /// <summary>
        /// Estimates sigma
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        private static double EstimateSigma(LinkedList<Price> prices) {
            //TODO not complete
            
            var length = (double)prices.Count;
            var node = prices.First;
            var mean = node.Value.BestAsk / length;
            while (node != prices.Last) {
                node = node.Next;
                mean += node.Value.BestAsk / length;
            }

            node = prices.First;
            var variance = Math.Pow(mean - node.Value.BestAsk, 2);
            while (node != prices.Last) {
                node = node.Next;
                variance = Math.Pow(mean - node.Value.BestAsk, 2);
            }

            return Math.Sqrt(variance / (length - 1)); 
        }
    }
}