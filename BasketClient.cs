namespace Supermarket
{
    public class BasketClient
    {
        private readonly Dictionary<int, Product> _basket = new Dictionary<int, Product>();

        public void Add(int key, Product product)
        {
            _basket.Add(key, product);
        }

        public void Remove(int key)
        {
            _basket.Remove(key);
        }

        public void Display()
        {
            foreach (KeyValuePair<int, Product> marketProduct in _basket)
            {
                Console.WriteLine($"Индекс: {marketProduct.Key}." +
                    $"Сумма: {marketProduct.Value.Price}." +
                    $"Название: {marketProduct.Value.Name}.");
                Console.WriteLine();
            }
        }

        public int TryAddProduct(int key, Product product)
        {
            if (_basket.ContainsKey(key))
            {
                return key++;
            }
            else
            {
                _basket.Add(key, product);
            }
            return key;
        }

        public void Clear()
        {
            _basket.Clear();
        }
    }
}
