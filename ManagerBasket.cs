namespace Supermarket
{
    public class ManagerBasket
    {
        private readonly Warehouse _warehouse = new Warehouse();
        private readonly BasketClient _basketClient = new BasketClient();
        private readonly CashRegister _cashRegister = new CashRegister();
        private readonly QueuePeople _queuePeople = new QueuePeople();
        private readonly WalletClient _walletClient = new WalletClient();
        private readonly Product _product = new Product(0, "", 0);

        public void BasketFillIn(string indexAdd, int _walletSum)
        {
            if (int.TryParse(indexAdd, out int productChoice))
            {
                if (_warehouse.TryGetProduct(productChoice, out Product product))
                {
                    if (_walletSum >= product.Price)
                    {
                        _basketClient.TryAddProduct(productChoice, product);
                        _cashRegister.DisplayBuySuccess(product.Price);
                        _cashRegister.CalculatedBuy(product.Price);
                        _basketClient.Display();
                    }
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
            _queuePeople.Remove();
            _queuePeople.StatusQueue();
            _queuePeople.Display();
            _walletClient.SumWallet = 0;
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
