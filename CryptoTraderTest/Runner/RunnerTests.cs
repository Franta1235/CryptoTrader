using System;
using CryptoTrader.Runner;
using CryptoTrader.Strategy;
using NUnit.Framework;

namespace CryptoTraderTest.Runner
{
    [TestFixture]
    public class RunnerTests
    {
        [Test]
        public void Test1() {
            var runner = new HistoryRunner(string.Empty);
            var strategy = new TestStrategy();
            runner.Run(strategy);
        }
    }
}