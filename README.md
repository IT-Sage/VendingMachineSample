# VendingMachineSample
This library provides simple algorithm returning minimal count of coins available for given amount.

## Usage
As you can see in [Tests](https://github.com/IT-Sage/VendingMachineSample/blob/master/VendingMachine.Tests/GetCoinsTests.cs).
Provide array of integers representing available coin values.
```
int[] availableCoins = { 2, 5 };
```
Then pass the array into `CoinService` constructor.
```
 var coinService = new CoinService(availableCoins);
```
Then call `GetCoins(int amount)` method with desired amount to return on input and you get list of coins as an output.
```
var coins = coinService.GetCoins(8)
```

In case the change isn't possible for given `availableCoins` and desired `amount`, you'll recieve an `Exception` containing message: `"Change is not possible."`.
