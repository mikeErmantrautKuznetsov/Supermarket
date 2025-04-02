namespace Supermarket
{
    public class WalletQueue
    {
        private readonly static List<Wallet> _walletClient = new List<Wallet>()
        {
            new Wallet(6000),
            new Wallet(4000),
            new Wallet(7000),
            new Wallet(8000),
            new Wallet(9000)
        };

        private readonly Queue<Wallet> _wallets = new Queue<Wallet>(_walletClient);

        public void Display()
        {
            foreach (var Queue in _wallets)
            {
                Console.WriteLine($"Сумма кошелька: {Queue.MoneyAmount}.");
            }

            Console.WriteLine();
        }

        public int Add(int sum)
        {
            var sumWallet = _wallets.Dequeue();
            sum = sumWallet.MoneyAmount;
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
