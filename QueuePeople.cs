namespace Supermarket
{
    public class QueuePeople
    {
        private readonly static List<Client> _clientsList = new List<Client>()
        {
            new Client("Кирилл"),
            new Client("Рома"),
            new Client("Антон"),
            new Client("Лена"),
            new Client("Маша")

        };

        private readonly Queue<Client> _clients = new Queue<Client>(_clientsList);

        public void Display()
        {
            foreach (var clientQueue in _clients)
            {
                Console.WriteLine($"Список: {clientQueue.Name}.");
            }

            Console.WriteLine();
        }

        public void Remove()
        {
            if (_clients.Count != 0)
            {
                _clients.Dequeue();
            }
        }

        public void StatusQueue()
        {
            if (_clients.Count <= 0)
            {
                Console.WriteLine("Очередь пуста. Можно закрывать магазин.");
            }
        }
    }
}
