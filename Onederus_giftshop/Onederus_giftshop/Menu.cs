using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onederus_giftshop
{
    public class Menu
    {
        public List<GiftProduct> ListOfProducts { get; set; }

        public List<GiftProduct> GiftList()
        {
            List<GiftProduct> list = new List<GiftProduct>();
            list.Add(new GiftProduct("1. T-shirt", "Clothing", "T-shirts in all sizes", 14.99));
            list.Add(new GiftProduct("2. Hat", "Clothing", "Baseball caps or knitted hats", 17.99));
            list.Add(new GiftProduct("3. Scarf", "Clothing", "One size fits all", 12.99));
            list.Add(new GiftProduct("4. Sweatshirt", "Clothing", "One size fits all", 29.99));
            list.Add(new GiftProduct("5. Sunglasses", "Clothing", "Men, women, and children styles", 11.99));
            list.Add(new GiftProduct("6. Coffee", "Food", "One size only", 4.75));
            list.Add(new GiftProduct("7. Pop", "Food", "20 oz bottle", 2.50));
            list.Add(new GiftProduct("8. Candy Bar", "Food", "Milk or dark chocolate", 3.50));
            list.Add(new GiftProduct("9. Beer", "Food", "Cider also available for same price! 12oz can", 5.50));
            list.Add(new GiftProduct("10. Postcard", "Novelties", "Various styles", 0.50));
            list.Add(new GiftProduct("11. Shot Glass", "Novelties", "You drink from it!", 7.99));
            list.Add(new GiftProduct("12. Book", "Novelties", "Books on local culture", 15.99));
            list.Add(new GiftProduct("13. Magnet", "Novelties", "Refrigerator magnets", 3));
            return list;
        }
        public void DisplayGiftShopList(List<string> list)
        {
            Console.Clear();
            Console.WriteLine("These are the available items for sale in the gift shop: ");
            foreach (string product in GiftList())
                { Console.WriteLine(product.Name + "," + product.Price); }
            
        }
    }
}
