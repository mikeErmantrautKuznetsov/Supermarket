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
                Console.WriteLine($"Индекс: {marketProduct.Key}." +
                    $"Сумма: {marketProduct.Value.Price}." +
                    $"Название: {marketProduct.Value.Name}.");
                Console.WriteLine();
            }
        }

        public int AddProduct(int key, Product product)
        {
            if (_basket.ContainsKey(key))
            {
                int newKey = 1;
                while (true)
                {
                    if (!_basket.ContainsKey(newKey))
                    {
                        _basket.Add(newKey, product);
                        break;
                    }
                    newKey++;
                }
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
