namespace Supermarket
{
    public class Warehouse 
    {
        private readonly Dictionary<int, Product> _shelves = new Dictionary<int, Product>()
        {
            {1, new Product(1300, "Сосиски", 100000) },
            {2, new Product(200, "Конфеты", 1000000) },
            {3, new Product(1500, "Колбаса", 1000000) },
            {4, new Product(600, "Сыр", 1000000) },
            {5, new Product(1200, "Творог", 100000) },
            {6, new Product(2000, "Коньяк", 100000) },
        };

        public void DisplayWareHouse()
        {
            foreach (KeyValuePair<int, Product> marketProduct in _shelves)
            {
                Console.WriteLine($"Индекс: {marketProduct.Key}." +
                    $"Сумма: {marketProduct.Value.Price}." +
                    $"Название: {marketProduct.Value.Name}." +
                    $"Количество: {marketProduct.Value.Quantity}.");
                Console.WriteLine();
            }
        }

        public bool TryGetProduct(int keyProduct, out Product products)
        {
            products = null;

            if (_shelves.ContainsKey(keyProduct))
            {
                products = _shelves[keyProduct];
                return true;
            }
            return false;
        }
    }
}
