using Onederus_giftshop;
using System.Data;

Menu menu = new Menu();
Register receipt = new Register();
List<GiftProduct> shoppingCart = new List<GiftProduct>();
menu.GiftList();

bool isShopping = true;

while (isShopping)
{
    Console.WriteLine("Welcome to the Onederful Gift Shop!\n ");
    menu.DisplayGiftShopList();
 
    while (true)
    {
        Console.WriteLine("Please enter the number of the item you wish to purchase.");
        int n = InputValidation.IsInt();
        int i = n - 1;
        if (n >= 0 && n <= menu.ListOfProducts.Count)
        {
            Console.WriteLine("How many would you like to purchase?");
            double quantity = InputValidation.IsDouble();
            menu.GetLineTotal(i, quantity);
            menu.AddToCart(shoppingCart, i, quantity);

            Console.WriteLine("Would you like to continue shopping? y/n");
            string keepShopping = InputValidation.IsString(Console.ReadLine());
            if (keepShopping != "y")
            {
                receipt.DisplayTotal(shoppingCart);
                break;
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid menu option.");
        }
    }

    Console.WriteLine("Would you like to start a new order?");
    string newOrder = InputValidation.IsString(Console.ReadLine());
    if (newOrder != "y")
    {
        isShopping = false;
    }
    else
    {
        shoppingCart.Clear();
        Console.Clear();
    }
}