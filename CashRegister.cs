namespace Supermarket
{
    public class CashRegister
    {
        private readonly Warehouse _warehouse = new Warehouse();
        private readonly SupermarketBank _supermarketBank = new SupermarketBank();
        private readonly WalletClient _walletClient = new WalletClient();
        private readonly Product _product = new Product(1, "", 1);

        public void WelcomeAndGo()
        {
            Console.WriteLine("Свободная касса:");
            Console.ReadKey();
            Console.WriteLine("Приветствуем в нашем магазине.");
            Console.WriteLine();
            _warehouse.Display();
        }

        public void CalculatedBuy(int priceBuy)
        {
            if (_walletClient.SumWallet >= priceBuy)
            {
                _walletClient.SumWallet -= priceBuy;
                _supermarketBank.Money += priceBuy;
            }
        }

        public void DisplayBuySuccess(int priceBuy)
        {
            Console.WriteLine("Транзакция совершена.");
            Console.WriteLine("Товары добавленные в корзину.");
            Console.WriteLine($"Баланс магазина: {_supermarketBank.Money += priceBuy}.");
            Console.WriteLine($"Сумма покупок: {priceBuy}.");
            Console.WriteLine($"Количество продуктов: {_product.Quantity++}");
        }

        public void DisplaySell(int priceSell)
        {
            Console.WriteLine($"Баланс магазина: {_supermarketBank.Money -= priceSell}.");
            Console.WriteLine($"Баланс кошелька: {_walletClient.SumWallet += priceSell}.");
            Console.WriteLine($"Количество продуктов: {_product.Quantity--}");
        }
    }
}
