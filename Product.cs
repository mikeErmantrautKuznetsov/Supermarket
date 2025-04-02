namespace Supermarket
{
    public class Product
    {
        public int Price { get; private set; }
        public int Quantity { get; private set; }

        public string Name { get; private set; }

        public Product(int price, string name, int quantity)
        {
            Price = price; 
            Name = name;
            Quantity = quantity;
        }
    }
}
