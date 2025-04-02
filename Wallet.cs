namespace Supermarket
{
    public class Wallet
    {
        public int MoneyAmount { get; private set; }

        public Wallet(int moneyAmount)
        {
            MoneyAmount = moneyAmount;
        }

        public void Spend(int moneyAmount)
        {
            if (MoneyAmount < moneyAmount)
            {
                throw new ArgumentException("Not enough money");
            }

            MoneyAmount -= moneyAmount;
        }

        public void Add(int moneyAmount)
        {
            if(moneyAmount < 0)
            {
                throw new ArgumentException("I can't negative add money.");
            }

            MoneyAmount += moneyAmount;
        }

    }

}
