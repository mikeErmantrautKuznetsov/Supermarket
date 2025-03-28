namespace Supermarket
{
    public class Basket
    {
        private readonly Dictionary<int, Product> _basket = new Dictionary<int, Product>();

        public void Remove(int key)
        {
            _basket.Remove(key);
        }

        public void Display()
        {
            foreach (KeyValuePair<int, Product> marketProduct in _basket)
            {
                Console.WriteLine($"Номер: {marketProduct.Key}." +
                    $"Сумма: {marketProduct.Value.Price}." +
                    $"Название: {marketProduct.Value.Name}.");
                Console.WriteLine();
            }
        }

        public int AddProduct(int key, Product product)
        {
            if (_basket.TryAdd(key, product))
            {
                return key;
            }
            else
            {
                int newKey = _basket.Keys.Max() + 1;
                _basket.Add(newKey, product);
                return newKey;
            }
        }

        public void Clear()
        {
            _basket.Clear();
        }
    }
}
