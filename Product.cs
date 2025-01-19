namespace Supermarket
{
    public class Product
    {
        private int _price;
        private int _quantity;

        private string _name;

        public int Price { get { return _price; } set { _price = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }

        public string Name { get { return _name; } set { _name = value; } }

        public Product(int price, string name, int quantity)
        {
            Price = price; 
            Name = name;
            Quantity = quantity;
        }
    }
}
