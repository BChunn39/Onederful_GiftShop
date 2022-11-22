namespace Onederus_giftshop
{
    public class Novelties : GiftProduct
    {
        public string ItemType { get; set; }
        public Novelties(string name, string itemType, string description, double price)
        {
            Name = name;
            ItemType = itemType;
            Description = description;
            Price = price;
        }
    }
}
