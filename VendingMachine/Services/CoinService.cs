using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Model;

namespace VendingMachine.Services
{
    /// <summary>
    /// Service for processing Coins.
    /// </summary>
    public class CoinService
    {
        private readonly IReadOnlyList<Coin> availableCoins;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="availableCoins">Possible coin values.</param>
        public CoinService(int[] availableCoins)
        {
            this.availableCoins = InitializeAvailableCoins(availableCoins);
        }

        /// <summary>
        /// Method returning minimal count of coins necessary for equaling exchangeValue.
        /// </summary>
        /// <param name="exchangeValue">Expected amount to return.</param>
        /// <returns>Collection of coins of given amount.</returns>
        public List<Coin> GetCoins(int exchangeValue)
        {
            var coinsPerValue = new List<List<Coin>>(exchangeValue + 1);
            for (int i = 0; i < exchangeValue + 1; i++)
            {
                coinsPerValue.Add(new List<Coin>());
            }

            for (int value = 1; value <= exchangeValue; value++)
            {
                foreach (var availableCoin in availableCoins.Where(c => c.Value <= value))
                {
                    int subValue = value - availableCoin.Value;

                    // Is change for subvalue possible?
                    if (subValue > 0 && coinsPerValue[subValue].Count == 0)
                    {
                        continue;
                    }

                    if (coinsPerValue[value].Count == 0
                        || coinsPerValue[value].Count > coinsPerValue[subValue].Count + 1)
                    {
                        coinsPerValue[value] = coinsPerValue[subValue].ToList();
                        coinsPerValue[value].Add(availableCoin);
                    }
                }
            }

            if (coinsPerValue[exchangeValue].Count == 0)
            {
                throw new Exception("Change is not possible.");
            }

            return coinsPerValue[exchangeValue];
        }

        /// <summary>
        /// Method returning minimal count of coins necessary for equaling exchangeValue.
        /// Only for the so-called canonical coin systems.
        /// </summary>
        /// <param name="exchangeValue">Expected amount to return.</param>
        /// <returns>Collection of coins of given amount.</returns>
        public List<Coin> GetCoinsBasic(in int exchangeValue)
        {
            int remainingValue = exchangeValue;

            var returnCoins = new List<Coin>();
            foreach (Coin availableCoin in availableCoins)
            {
                if (remainingValue >= availableCoin.Value)
                {
                    int count = remainingValue / availableCoin.Value;
                    for (int j = 0; j < count; j++)
                    {
                        returnCoins.Add(new Coin(availableCoin.Value));
                    }

                    remainingValue %= availableCoin.Value;
                }
            }

            return returnCoins;
        }

        private IReadOnlyList<Coin> InitializeAvailableCoins(int[] availableCoins)
        {
            Array.Sort(availableCoins);
            Array.Reverse(availableCoins);

            List<Coin> availableCoinsList = new List<Coin>(availableCoins.Length);
            foreach (int coinValue in availableCoins)
            {
                availableCoinsList.Add(new Coin(coinValue));
            }

            return availableCoinsList.AsReadOnly();
        }
    }
}
