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
            WalletClient walletClient = new WalletClient(1);
            CashRegister cashRegister = new CashRegister();
            ManagerBasket managerBasket = new ManagerBasket();
            QueuePeople queuePeople = new QueuePeople();
            QueueValue queueValue = new QueueValue();
            WalletQueue walletQueue = new WalletQueue();

            cashRegister.WelcomeAndGo();
            Console.WriteLine();
            Console.WriteLine("Очередь покупателей.");
            queuePeople.Display();
            int sumClient = walletQueue.Add(walletClient.SumWallet);

            while (queueValue.ExitProgram != true)
            {
                Console.WriteLine("Выберите нужный пункт: " +
                    "\n1 - Начала обслуживание клиента. " +
                    "\n2 - Добавить продукты в корзину. " +
                    "\n3 - Купить продукты и уйти из магазина. " +
                    "\n4 - Выйти из программы. " +
                    "\n5 - Убрать продукт по индексу. ");
                string inputCommand = Console.ReadLine();
                if (int.TryParse(inputCommand, out int numberCommand))
                    switch (numberCommand)
                    {
                        case (int)InputCommandCashRegister.StartBuy:
                            Console.WriteLine("Следующий клиент.");
                            sumClient = walletQueue.Add(walletClient.SumWallet);
                            Console.WriteLine($"Сумма кошелька: {sumClient}.");
                            break;
                        case (int)InputCommandCashRegister.ChoiceProduct:
                            Console.WriteLine("Выберите продукты:");
                            string product = Console.ReadLine();
                            managerBasket.BasketFillIn(product, sumClient);
                            break;
                        case (int)InputCommandCashRegister.BuyLeave:
                            Console.WriteLine("Покупатель покидаете магазин, c сумкой продуктов: " +
                                "\nДля продолжение нажмите любую клавишу, после выберите пункт обслуживание следующего клиента.");
                            managerBasket.BuyAndLeave();
                            break;
                        case (int)InputCommandCashRegister.ExitProgram:
                            Console.WriteLine("Выход из программы.");
                            queueValue.ExitProgram = true;
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

public enum InputCommandCashRegister
{
    StartBuy = 1,
    ChoiceProduct,
    BuyLeave,
    ExitProgram,
    DeleteProduct,
}