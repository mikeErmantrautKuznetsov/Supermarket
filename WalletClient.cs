namespace Supermarket
{
    public class WalletClient
    {
        private Random random = new Random();

        public int SumWallet { get; set; }

        public int Generate(int minValue, int maxValue)
        {
            SumWallet = random.Next(minValue, maxValue);
            return SumWallet;
        }
    }
}
