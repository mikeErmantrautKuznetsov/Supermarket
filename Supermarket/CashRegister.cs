namespace Supermarket
{
    public class CashRegister
    {
        private readonly Warehouse _warehouse = new Warehouse();
        private readonly Bank _supermarketBank = new Bank();
        private readonly Product _product = new Product(0, "", 0);

        public void Welcome()
        {
            Console.WriteLine("Свободная касса:");
            Console.ReadKey();
            Console.WriteLine("Приветствуем в нашем магазине.");
            Console.WriteLine();
            _warehouse.Display();
        }

        public void Calculated(int priceBuy, int walletClient)
        {
            _supermarketBank.Money += priceBuy;
            walletClient -= _supermarketBank.Money;
            _product.Quantity++;
            Display(priceBuy, _product.Quantity, _supermarketBank.Money, walletClient);
        }

        public void Clear()
        {
            _supermarketBank.Money = 0;
            _product.Quantity = 0;
        }

        private void Display(int priceBuy, int product, int bankMoney, int wallet)
        {
            Console.WriteLine("Транзакция совершена.");
            Console.WriteLine("Товары добавленные в корзину.");
            Console.WriteLine($"Баланс покупки: {bankMoney}.");
            Console.WriteLine($"Сумма покупки: {priceBuy}.");
            Console.WriteLine($"Количество продуктов: {product}.");
            Console.WriteLine($"Баланс вашего кошелька: {wallet}.");
        }
    }
}
