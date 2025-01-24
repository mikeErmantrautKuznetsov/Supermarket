namespace Supermarket
{
    public class WalletClient
    {
        private int _sumWallet;

        public int SumWallet { get { return _sumWallet; } set { _sumWallet = value; } }

        public WalletClient(int sumWallet)
        {
            SumWallet = sumWallet;
        }
    }
}
