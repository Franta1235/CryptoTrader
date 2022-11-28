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

        public CandleList(int maxNodes) {
            _maxNodes = maxNodes;
            _candles = new LinkedList<ICandle>();
        }

        /// <summary>
        /// If #nodes > max_nodes, then is removed last node
        /// </summary>
        /// <param name="candle"></param>
        public new void AddFirst(ICandle candle) {
            _candles.AddFirst(candle);
            if (_candles.Count > _maxNodes) {
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
        /// Returns false, if something is wrong (Empty candles, candles with missing data etc)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsComplete() {
            throw new NotImplementedException();
        }
    }
}