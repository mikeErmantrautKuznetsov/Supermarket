namespace Supermarket
{
    public class ManagerBasket
    {
        private readonly Warehouse _warehouse = new Warehouse();
        private readonly BasketClient _basketClient = new BasketClient();
        private readonly CashRegister _cashRegister = new CashRegister();
        private readonly QueuePeople _queuePeople = new QueuePeople();
        private readonly Product _product = new Product(0, "", 0);
        private readonly WalletQueue _walletQueue = new WalletQueue();

        public void BasketFillIn(string indexAdd, int walletSum)
        {
            if (int.TryParse(indexAdd, out int productChoice))
            {
                if (_warehouse.TryGetProduct(productChoice, out Product product))
                {
                    _basketClient.TryAddProduct(productChoice, product);
                    _cashRegister.CalculatedBuy(product.Price, walletSum);
                    _basketClient.Display();
                }
            }
        }

        public void BasketClear()
        {
            _basketClient.Clear();
        }

        public void BuyAndLeave()
        {
            _basketClient.Display();
            Console.ReadLine();
            _queuePeople.StatusQueue();
            _queuePeople.Remove();
            _walletQueue.Remove();
            _walletQueue.Display();
            _queuePeople.Display();
            _product.Quantity = 0;
            BasketClear();
        }

        public void BasketFillOut(string indexRemove)
        {
            if (int.TryParse(indexRemove, out int productChoice))
            {
                _basketClient.Remove(productChoice);
                _basketClient.Display();
                if (_warehouse.TryGetProduct(productChoice, out Product product))
                {
                    _cashRegister.DisplaySell(product.Price);
                }
            }
        }
    }
}
