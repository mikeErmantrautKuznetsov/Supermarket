namespace Supermarket
{
    public class BasketClient  //Товары на добавление в сумку или удаление
    {
        private readonly Dictionary<int, Products> _basket = new Dictionary<int, Products>();

        public void AddBasket(int key, Products products)
        {
            _basket.Add(key, products);
        }

        public void RemoveBasket(int key)
        {
            _basket.Remove(key);
        }

        public void DisplayBasket()
        {
            foreach (KeyValuePair<int, Products> marketProduct in _basket)
            {
                Console.WriteLine($"Индекс: {marketProduct.Key} ." +
                    $"Сумма: {marketProduct.Value.Price} ." +
                    $"Название: {marketProduct.Value.Name} .");
                Console.WriteLine();
            }
        }

        public void ClearBasket()
        {
            _basket.Clear();
        }

        public bool TryGetProduct(int keyProduct, out Products products)
        {
            products = null;

            if (_basket.ContainsKey(keyProduct))
            {
                products = _basket[keyProduct];
                return true;
            }
            return false;
        }
    }
}
