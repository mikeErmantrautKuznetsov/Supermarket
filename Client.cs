namespace Supermarket
{
    public class Client
    {
        private string _name;

        public string Name { get { return _name; } set { _name = value; } }

        public Client(string name)
        {
            _name = name;
        }
    }
}
