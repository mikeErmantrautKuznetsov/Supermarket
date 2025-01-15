namespace Supermarket
{
    public class CashRegister           // касса
    {
        private readonly Supermarket _supermarket = new Supermarket();
        private readonly SupermarketBank _supermarketBank = new SupermarketBank();
        private readonly WalletClient _walletClient = new WalletClient();

        public void Welcome()
        {
            Console.WriteLine("Свободная касса:");
            Console.ReadKey();
            Console.WriteLine("Приветствуем в нашем магазине. Напишите сумму вашего кошелька.");
            Console.WriteLine();
            _supermarket.DisplaySupermarket();
        }

        public void CalculatedBuy(int priceBuy)
        {
            if (_walletClient.SumWallet >= _walletClient.SumBuy)
            {
                _walletClient.SumBuy = priceBuy;
                _walletClient.SumWallet = _walletClient.SumWallet - _walletClient.SumBuy;
                _supermarketBank.Money = _supermarketBank.Money + _walletClient.SumBuy;
                Console.WriteLine("Транзакция совершена.");
                Console.WriteLine("Товары добавленные в сумку.");
            }
            else
            {
                Console.WriteLine("Недостаточно средств для совершение транзакции. \nУберите лишние продукты.");
            }

            Console.WriteLine($"Сумма покупок: {priceBuy}.");
            Console.WriteLine($"Баланс магазина: {_supermarketBank.Money}.");
            Console.WriteLine($"Кошелек клиента: {_walletClient.SumWallet}.");

        }
    }
}
