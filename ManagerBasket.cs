namespace Supermarket
{
    public class ManagerBasket
    {
        private readonly Warehouse _warehouse;
        private readonly Basket _basketClient;
        private readonly CashRegister _cashRegister;
        private readonly QueuePeople _queuePeople;
        private readonly WalletQueue _walletQueue;
        private readonly Wallet _supermarketWallet;

        public ManagerBasket(Warehouse warehouse, Basket basketClient, CashRegister cashRegister, QueuePeople queuePeople, WalletQueue walletQueue, Wallet supermarketWallet)
        {
            _warehouse = warehouse;
            _basketClient = basketClient;
            _cashRegister = cashRegister;
            _queuePeople = queuePeople;
            _walletQueue = walletQueue;
            _supermarketWallet = supermarketWallet;
        }

        public void BasketFillIn(string indexAdd)
        {
            if (int.TryParse(indexAdd, out int productChoice))
            {
                if (_warehouse.TryGetProduct(productChoice, out Product product))
                {
                    _basketClient.Add(productChoice, product);
                    _cashRegister.Calculated(product.Price);
                    _basketClient.Display();
                }
            }
        }

        public void BasketClear()
        {
            _basketClient.Clear();
        }

        public void Leave()
        {
            _basketClient.Display();
            Console.ReadLine();
            _queuePeople.StatusQueue();
            _queuePeople.Remove();
            _walletQueue.Remove();
            _walletQueue.Display();
            _queuePeople.Display();
            BasketClear();
            _walletQueue.Queue();
        }

        public void BasketFillOut(string indexRemove)
        {
            if (int.TryParse(indexRemove, out int productChoice))
            {
                if (_warehouse.TryGetProduct(productChoice, out Product product))
                {
                    _cashRegister.DisplayBuySuccess(product.Price, _supermarketWallet.MoneyAmount);
                    _basketClient.Remove(productChoice);
                    _walletQueue.Add(product.Price);
                    _basketClient.Display();
                }
            }
        }
    }
}
