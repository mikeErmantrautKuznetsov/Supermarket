namespace Supermarket
{
    public class WalletQueue
    {
        private readonly static List<WalletClient> _walletClient = new List<WalletClient>()
        {
            new WalletClient(6000),
            new WalletClient(4000),
            new WalletClient(7000),
            new WalletClient(8000),
            new WalletClient(9000)
        };

        private readonly Queue<WalletClient> _wallets = new Queue<WalletClient>(_walletClient);

        public void Display()
        {
            foreach (var Queue in _wallets)
            {
                Console.WriteLine($"Сумма кошелька: {Queue.SumWallet}.");
            }

            Console.WriteLine();
        }

        public int Add(int sum)
        {
            var sumWallet = _wallets.Dequeue();
            sum = sumWallet.SumWallet;
            return sum;
        }

        public void Remove()
        {
            _wallets.Dequeue();
        }

        public void Queue()
        {
            if (_wallets.Count <= 0)
            {
                throw new Exception("Очередь ровна нулю");
            }
        }
    }
}
