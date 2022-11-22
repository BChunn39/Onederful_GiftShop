using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onederus_giftshop
{
    public class Clothing : GiftProduct
    {
        public string Size { get; set; }
        public Clothing(string name, string size, string description, double price)
        {
            Name = name;
            Size = size;
            Description = description;
            Price = price;
        }
    }
}
