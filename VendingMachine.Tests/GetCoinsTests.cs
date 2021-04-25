using NUnit.Framework;
using System;
using VendingMachine.Services;

namespace VendingMachine.Tests
{
    public class Tests
    {
        private const string ExceptionMessage = "Change is not possible.";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int[] availableCoins = { 2, 5 };
            var coinService = new CoinService(availableCoins);
            var coins = coinService.GetCoins(8);

            Assert.That(coins.Count, Is.EqualTo(4));
        }

        [Test]
        public void Test2()
        {
            int[] availableCoins = { 2, 3, 6 };
            var coinService = new CoinService(availableCoins);
            var coins = coinService.GetCoins(11);

            Assert.That(coins.Count, Is.EqualTo(3));
        }

        [Test]
        public void Test3()
        {
            int[] availableCoins = { 2, 3, 6 };
            var coinService = new CoinService(availableCoins);
            var coins = coinService.GetCoins(13);

            Assert.That(coins.Count, Is.EqualTo(4));
        }

        [Test]
        public void Test4()
        {
            int[] availableCoins = { 1, 2, 5 };
            var coinService = new CoinService(availableCoins);
            var coins = coinService.GetCoins(8);

            Assert.That(coins.Count, Is.EqualTo(3));
        }

        [Test]
        public void Test5()
        {
            int[] availableCoins = { 1, 5, 6, 9 };
            var coinService = new CoinService(availableCoins);
            var coins = coinService.GetCoins(11);

            Assert.That(coins.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test6()
        {
            int[] availableCoins = { 2, 5 };
            var coinService = new CoinService(availableCoins);
            Assert.That(
                () => coinService.GetCoins(3),
                Throws.TypeOf<Exception>()
                    .With
                    .Message
                    .EqualTo(ExceptionMessage));
        }

        [Test]
        public void Test7()
        {
            int[] availableCoins = { 0 };
            var coinService = new CoinService(availableCoins);
            Assert.That(
                () => coinService.GetCoins(5),
                Throws.TypeOf<Exception>()
                    .With
                    .Message
                    .EqualTo(ExceptionMessage));
        }

        [Test]
        public void Test8()
        {
            int[] availableCoins = { 5, 7 };
            var coinService = new CoinService(availableCoins);
            Assert.That(
                () => coinService.GetCoins(11),
                Throws.TypeOf<Exception>()
                    .With
                    .Message
                    .EqualTo(ExceptionMessage));
        }

        [Test]
        public void Test9()
        {
            int[] availableCoins = { 2, 7 };
            var coinService = new CoinService(availableCoins);
            var coins = coinService.GetCoins(15);

            Assert.That(coins.Count, Is.EqualTo(5));
        }

        [Test]
        public void Test10()
        {
            int[] availableCoins = { 1, 2, 5 };
            var coinService = new CoinService(availableCoins);
            var coins = coinService.GetCoinsBasic(8);

            Assert.That(coins.Count, Is.EqualTo(3));
        }
    }
}