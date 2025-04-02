namespace Supermarket
{
    public class CashRegister
    {
        private readonly Warehouse _warehouse;
        private readonly Wallet _supermarketWallet;

        public CashRegister(Wallet supermarketBank, Warehouse warehouse)
        {
            _supermarketWallet = supermarketBank;
            _warehouse = warehouse;
        }

        public void DisplayWelcomeMessage()
        {
            Console.WriteLine("Свободная касса:");
            Console.ReadKey();
            Console.WriteLine("Приветствуем в нашем магазине.");
            Console.WriteLine();
            _warehouse.DisplayWareHouse();
        }

        public void Calculated(int priceBuy)
        {
            _supermarketWallet.Spend(priceBuy);
            DisplayBuySuccess(priceBuy, _supermarketWallet.MoneyAmount);
        }

        public void DisplayBuySuccess(int priceBuy, int wallet)
        {
            Console.WriteLine("Транзакция совершена.");
            Console.WriteLine("Товары добавленные в корзину.");
            Console.WriteLine($"Сумма покупки: {priceBuy}.");
            Console.WriteLine($"Деньги в кошельке: {wallet}.");
        }
    }
}
