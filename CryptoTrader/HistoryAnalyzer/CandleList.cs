using System;
using System.Collections.Generic;
using System.Linq;
using CryptoTrader.Helper.Candle;

namespace CryptoTrader.HistoryAnalyzer
{
    /// <summary>
    /// List for candles, it stores maximum N ICandles (nodes)
    /// </summary>
    public class CandleList
    {
        private readonly int _maxNodes;
        private readonly LinkedList<ICandle> _candles;
        private int _completeCandles;

        public CandleList(int maxNodes) {
            _maxNodes = maxNodes;
            _candles = new LinkedList<ICandle>();
            _completeCandles = 0;
        }

        /// <summary>
        /// If #nodes > max_nodes, then is removed last node
        /// </summary>
        /// <param name="candle"></param>
        public new void Add(ICandle candle) {
            _candles.AddFirst(candle);

            if (candle.GetType() == typeof(Candle)) {
                _completeCandles++;
            }

            if (_candles.Count > _maxNodes) {
                if (_candles.Last.GetType() == typeof(Candle)) {
                    _completeCandles--;
                }

                _candles.RemoveLast();
            }
        }

        /// <summary>
        /// Creates indexer
        /// </summary>
        /// <param name="index">Index of element</param>
        public ICandle this[int index] => _candles.ElementAt(index);

        /// <summary>
        /// Returns all candles
        /// </summary>
        /// <returns></returns>
        public LinkedList<ICandle> GetCandles() {
            return _candles;
        }

        /// <summary>
        /// Returns false, if something is wrong (Empty candles, candles with missing data etc), else return true
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsComplete() {
            return _completeCandles == _maxNodes;
            //throw new NotImplementedException();
        }
    }
}