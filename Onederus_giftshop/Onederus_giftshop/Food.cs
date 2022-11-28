namespace Onederus_giftshop
{
    public class Food : GiftProduct
    {
        public string TypeOfFood { get; set; }

        public Food(string name, string typeOfFood, string description, double price)
        {
            Name = name;
            TypeOfFood = typeOfFood;
            Description = description;
            Price = price;
        }
    }
}
