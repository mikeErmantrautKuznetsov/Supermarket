namespace Supermarket
{
    public class ManagerBasket
    {
        private readonly Warehouse _warehouse;
        private readonly Basket _basketClient;
        private readonly CashRegister _cashRegister;
        private readonly PeopleQueue _peopleQueue;
        private readonly WalletQueue _walletQueue;

        public ManagerBasket(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public ManagerBasket(Basket basketClient)
        {
            _basketClient = basketClient;
        }

        public ManagerBasket(CashRegister cashRegister)
        {
            _cashRegister = cashRegister;
        }

        public ManagerBasket(PeopleQueue peopleQueue)
        {
            _peopleQueue = peopleQueue;
        }

        public ManagerBasket(WalletQueue walletQueue)
        {
            _walletQueue = walletQueue;
        }

        public void BasketFillIn(string indexAdd, int walletSum)
        {
            ManagerBasket managerBasket = new ManagerBasket(new Basket());
            ManagerBasket managerWarehouse = new ManagerBasket(new Warehouse());
            ManagerBasket managerCash = new ManagerBasket(new CashRegister(new Warehouse()));

            if (int.TryParse(indexAdd, out int productChoice))
            {
                if (managerWarehouse._warehouse.TryGetProduct(productChoice, out Product product))
                {
                    managerBasket._basketClient.AddProduct(productChoice, product);
                    managerCash._cashRegister.Calculated(product.Price, walletSum);
                    managerBasket._basketClient.Display();
                }
            }
        }

        public void BasketClear()
        {
            ManagerBasket managerBasket = new ManagerBasket(new Basket());
            managerBasket._basketClient.Clear();
        }

        public void Buy()
        {
            ManagerBasket managerBasket = new ManagerBasket(new Basket());
            ManagerBasket managerPeopleQueue = new ManagerBasket(new PeopleQueue());
            ManagerBasket managerWalletQueue = new ManagerBasket(new WalletQueue());
            ManagerBasket managerCash = new ManagerBasket(new CashRegister(new Warehouse()));

            managerBasket._basketClient.Display();
            Console.ReadLine();
            managerPeopleQueue._peopleQueue.StatusQueue();
            managerPeopleQueue._peopleQueue.Remove();
            managerWalletQueue._walletQueue.Remove();
            managerWalletQueue._walletQueue.Display();
            managerPeopleQueue._peopleQueue.Display();
            managerCash._cashRegister.Clear();
            BasketClear();
        }

        public void BasketFillOut(string indexRemove)
        {
           ManagerBasket managerBasket = new ManagerBasket(new Basket());

            if (int.TryParse(indexRemove, out int productChoice))
            {
                managerBasket._basketClient.Remove(productChoice);
                managerBasket._basketClient.Display();
            }
        }
    }
}
