namespace Supermarket
{
    public class ManagerBasket
    {
        private readonly Warehouse _warehouse = new Warehouse();
        private readonly Basket _basketClient = new Basket();
        private readonly CashRegister _cashRegister = new CashRegister();
        private readonly PeopleQueue _peopleQueue = new PeopleQueue();
        private readonly WalletQueue _walletQueue = new WalletQueue();

        public void BasketFillIn(string indexAdd, int walletSum)
        {
            if (int.TryParse(indexAdd, out int productChoice))
            {
                if (_warehouse.TryGetProduct(productChoice, out Product product))
                {
                    _basketClient.AddProduct(productChoice, product);
                    _cashRegister.Calculated(product.Price, walletSum);
                    _basketClient.Display();
                }
            }
        }

        public void BasketClear()
        {
            _basketClient.Clear();
        }

        public void Buy()
        {
            _basketClient.Display();
            Console.ReadLine();
            _peopleQueue.StatusQueue();
            _peopleQueue.Remove();
            _walletQueue.Remove();
            _walletQueue.Display();
            _peopleQueue.Display();
            _cashRegister.Clear();
            BasketClear();
        }

        public void BasketFillOut(string indexRemove)
        {
            if (int.TryParse(indexRemove, out int productChoice))
            {
                _basketClient.Remove(productChoice);
                _basketClient.Display();
            }
        }
    }
}
