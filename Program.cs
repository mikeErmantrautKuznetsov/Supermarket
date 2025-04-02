namespace Supermarket
{
    //Написать программу администрирования супермаркетом.
    //Супермаркет содержит список товаров, которые он продает, очередь клиентов, которых надо обслужить и количество денег, которые заработаны.
    //Список товаров у супермаркета не уменьшаем, считаем их бесконечное количество.
    //Очередь клиентов можно задавать сразу, так и добавлять по необходимости.
    //Но при обслуживании одного клиента, он удаляется из очереди. 
    //У клиента есть деньги, корзина и сумка.
    //В корзине все товары, что не куплены, а в сумке все купленные.
    //При обслуживании клиента проверяется, может ли он оплатить товар, то есть сравнивается итоговая сумма покупки и количество денег.
    //Если оплатить клиент не может, то он случайный товар из корзины выкидывает до тех пор, пока его денег не хватит для оплаты.

    public class Program
    {
        private static void Main(string[] args)
        {
            Wallet walletClient = new Wallet(0);
            QueuePeople queuePeople = new QueuePeople();
            WalletQueue walletQueue = new WalletQueue();
            Wallet supermarketWallet = new Wallet(walletQueue.Add(walletClient.MoneyAmount));
            Warehouse warehouse = new Warehouse();
            Basket basket = new Basket();
            CashRegister cashRegister = new CashRegister(supermarketWallet, warehouse);
            ManagerBasket managerBasket = new ManagerBasket(warehouse, basket, cashRegister, queuePeople, walletQueue, walletClient);

            cashRegister.DisplayWelcomeMessage();
            Console.WriteLine();
            Console.WriteLine("Очередь покупателей.");
            queuePeople.Display();

            bool exitProgram = false;

            while (exitProgram != true)
            {
                Console.WriteLine("Выберите нужный пункт: " +
                    "\n1 - Добавить продукты в корзину. " +
                    "\n2 - Купить продукты и уйти из магазина. " +
                    "\n3 - Выйти из программы. " +
                    "\n4 - Убрать продукт по индексу. ");

                string inputCommand = Console.ReadLine();

                if (int.TryParse(inputCommand, out int numberCommand))
                {
                    switch (numberCommand)
                    {
                        case (int)InputCommandCashRegister.ChoiceProduct:
                            Console.WriteLine("Выберите продукты:");
                            string product = Console.ReadLine();
                            managerBasket.BasketFillIn(product);
                            break;
                        case (int)InputCommandCashRegister.BuyLeave:
                            Console.WriteLine("Покупатель покидаете магазин, c сумкой продуктов: " +
                                "\nДля продолжение нажмите любую клавишу, после выберите пункт обслуживание следующего клиента.");
                            managerBasket.Leave();
                            break;
                        case (int)InputCommandCashRegister.ExitProgram:
                            Console.WriteLine("Выход из программы.");
                            exitProgram = true;
                            break;
                        case (int)InputCommandCashRegister.DeleteProduct:
                            Console.WriteLine("Выберите продукт для удалению из корзины.");
                            string delete = Console.ReadLine();
                            managerBasket.BasketFillOut(delete);
                            break;
                    }
                }
            }
        }
    }
}

public enum InputCommandCashRegister
{
    ChoiceProduct = 1,
    BuyLeave,
    ExitProgram,
    DeleteProduct
}