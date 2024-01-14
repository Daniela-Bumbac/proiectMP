namespace PlatinumGym.Models
{
    public class Subscription
    {
        public int SubscriptionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Subscription(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }

}
