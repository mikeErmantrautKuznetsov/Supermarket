namespace Supermarket
{
    public class CashRegister
    {
        private readonly Warehouse _warehouse;
        private readonly Bank _supermarketBank;

        public CashRegister(Bank supermarketBank)
        {
            _supermarketBank = supermarketBank;
        }

        public CashRegister(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void DisplayWelcomeMessage()
        {
            Console.WriteLine("Свободная касса:");
            Console.ReadKey();
            Console.WriteLine("Приветствуем в нашем магазине.");
            Console.WriteLine();
            CashRegister cashRegister = new CashRegister(new Warehouse());
            cashRegister._warehouse.DisplayWareHouse();
        }

        public void Calculated(int priceBuy, int walletClient)
        {
            CashRegister cashRegister = new CashRegister(new Bank());
            cashRegister._supermarketBank.Money += priceBuy;
            walletClient -= cashRegister._supermarketBank.Money;
            Display(priceBuy, cashRegister._supermarketBank.Money, walletClient);
        }

        public void Clear()
        {
            CashRegister cashRegister = new CashRegister(new Bank());
            cashRegister._supermarketBank.Money = 1000;
        }

        private void Display(int priceBuy, int bankMoney, int wallet)
        {
            Console.WriteLine("Транзакция совершена.");
            Console.WriteLine("Товары добавленные в корзину.");
            Console.WriteLine($"Баланс покупки: {bankMoney}.");
            Console.WriteLine($"Сумма покупки: {priceBuy}.");
            Console.WriteLine($"Баланс вашего кошелька: {wallet}.");
        }
    }
}
