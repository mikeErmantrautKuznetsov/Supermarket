namespace Supermarket
{
    public class Supermarket    // Продукты на добавление в корзину
    {
        private readonly Dictionary<int, Products> _shelves = new Dictionary<int, Products>()
        {
            {1, new Products(1300, "Сосиски") },
            {2, new Products(200, "Конфеты") },
            {3, new Products(1500, "Колбаса") },
            {4, new Products(600, "Сыр") },
            {5, new Products(1200, "Творог") },
            {6, new Products(2000, "Коньяк") },
        };

        public void DisplaySupermarket()
        {
            foreach (KeyValuePair<int, Products> marketProduct in _shelves)
            {
                Console.WriteLine($"Индекс: {marketProduct.Key}." +
                    $"Сумма {marketProduct.Value.Price}." +
                    $"Название {marketProduct.Value.Name}.");
                Console.WriteLine();
            }
        }

        public bool TryGetProduct(int keyProduct, out Products products)
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
