namespace Supermarket
{
    public class Basket
    {
        private readonly Dictionary<int, List<Product>> _basket = new Dictionary<int, List<Product>>();

        public void Add(int key, Product product)
        {
            if (!_basket.ContainsKey(key))
            {
                _basket.Add(key, new List<Product>());
            }
            _basket[key].Add(product);
        }

        public void Remove(int key)
        {
            _basket.Remove(key);
        }

        public void Display()
        {
            foreach (KeyValuePair<int, List<Product>> marketProduct in _basket)
            {
                foreach (Product product in marketProduct.Value)
                {
                    Console.WriteLine($"Индекс: {marketProduct.Key}." +
                        $"Сумма: {product.Price}." +
                        $"Название: {product.Name}.");
                    Console.WriteLine();
                }
            }
        }

        public void Clear()
        {
            _basket.Clear();
        }
    }
}
