namespace Supermarket
{
    public class ManagerBasket
    {
        private readonly Supermarket _supermarket = new Supermarket();
        private readonly BasketClient _basketClient = new BasketClient();
        private readonly CashRegister _cashRegister = new CashRegister();
        private readonly WalletClient _walletClient = new WalletClient();

        public void BasketFillIn(string indexAdd)
        {
            if (int.TryParse(indexAdd, out int productChoice))
            {
                if (_supermarket.TryGetProduct(productChoice, out Products product))
                {
                    if (_walletClient.SumWallet >= product.Price)
                    {
                        _basketClient.AddBasket(productChoice, product);
                        _basketClient.DisplayBasket();
                        _cashRegister.CalculatedBuy(product.Price);
                    }
                }
            }
        }

        public void BasketClear()
        {
            _basketClient.ClearBasket();
        }

        public void BasketFillOut(string indexRemove)
        {
            if (int.TryParse(indexRemove, out int productChoice))
            {
                _basketClient.RemoveBasket(productChoice);
                _basketClient.DisplayBasket();
            }
        }
    }
}
