using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
