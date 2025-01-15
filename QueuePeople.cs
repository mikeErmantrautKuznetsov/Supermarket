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

        private readonly Queue<Client> _clientsQueue = new Queue<Client>(_clientsList);

        public void DisplayQueue()
        {
            foreach (var clientQueue in _clientsQueue)
            {
                Console.WriteLine($"Список: {clientQueue.Name}.");
            }
            Console.WriteLine();
        }

        public void RemoveClient()
        {
            if (_clientsQueue.Count != 0)
            {
                _clientsQueue.Dequeue();
            }
            else
            {
                Console.WriteLine("Очередь пуста. Можно закрывать магазин.");
            }
        }
    }
}
