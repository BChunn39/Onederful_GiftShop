using Onederus_giftshop;

Menu menu = new Menu();
Register reciept = new Register();
List<GiftProduct> shoppingCart = new List<GiftProduct>();
menu.GiftList();

Console.WriteLine("Hello, welcome to the Onederful Gift Shop. Would you like to view the list of items for sale? (y/n)");
string menuReply = Console.ReadLine().ToLower();

if (menuReply == "y")
{
    menu.DisplayGiftShopList();
}
else
{
    Console.WriteLine("Thank you, come again!");
}

while (true)
{
    Console.WriteLine("Please enter the number for the item you wish to purchase.");
    int n = Convert.ToInt32(Console.ReadLine());
    int i = n - 1;
    if (n >= 0 && n <= menu.ListOfProducts.Count)
    {
        Console.WriteLine("How many would you like to purchase?");
        double quantity = Convert.ToDouble(Console.ReadLine());
        menu.GetLineTotal(i, quantity);
        menu.AddToCart(shoppingCart, i, quantity);

        Console.WriteLine("Would you like to continue? y/n");
        string yn = Console.ReadLine();
        if (yn != "y")
        {
            reciept.DisplayTotal(shoppingCart);
            break;
        }
    }
    else
    {
        Console.WriteLine("please enter a valid number");
    }

}
