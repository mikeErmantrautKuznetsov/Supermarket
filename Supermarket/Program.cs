namespace Supermarket
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Wallet walletClient = new Wallet(1);
            CashRegister cashRegister = new CashRegister(new Warehouse());
            ManagerBasket managerBasket = new ManagerBasket(new CashRegister(new Warehouse()));
            PeopleQueue queuePeople = new PeopleQueue();
            WalletQueue walletQueue = new WalletQueue();

            cashRegister.DisplayWelcomeMessage();
            Console.WriteLine();
            Console.WriteLine("Очередь покупателей.");
            queuePeople.Display();

            int sumClient = walletQueue.Add(walletClient.SumWallet);
            

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
                            managerBasket.BasketFillIn(product, sumClient);
                            break;
                        case (int)InputCommandCashRegister.Buy:
                            Console.WriteLine("Покупатель покидаете магазин, c сумкой продуктов: " +
                                "\nДля продолжение нажмите любую клавишу, после выберите пункт обслуживание следующего клиента.");
                            sumClient = walletQueue.Add(walletClient.SumWallet);
                            managerBasket.Buy();
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
    Buy,
    ExitProgram,
    DeleteProduct
}