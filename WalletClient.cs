namespace Supermarket
{
    public class WalletClient
    {
        private int _sumWallet = 30000;
        private int _sumBuy = 0;

        public int SumWallet { get { return _sumWallet; } set { _sumWallet = value; } }
        public int SumBuy { get { return _sumBuy; } set { _sumBuy = value; } }
    }
}
