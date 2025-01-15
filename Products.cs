namespace Supermarket
{
    public class Products
    {
        private int _price;

        private string _name;

        public int Price { get { return _price; } set { _price = value; } }

        public string Name { get { return _name; } set { _name = value; } }


        public Products(int price, string name)
        {
            _price = price; 
            _name = name;
        }
    }
}
