namespace VendingMachine.Model
{
    /// <summary>
    /// Struct representing Coin with the nominal value.
    /// </summary>
    public struct Coin
    {
        public Coin(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }
    }
}
