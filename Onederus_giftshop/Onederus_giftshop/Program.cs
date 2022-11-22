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
while (true)
{
    Console.WriteLine("Please enter the number for the item you wish to purchase.");
    int n = Convert.ToInt32(Console.ReadLine()) - 1;

    Console.WriteLine("How many would you like to purchase?");
    double quantity = Convert.ToDouble(Console.ReadLine());
    menu.GetLineTotal(n, quantity);
    menu.AddToCart(shoppingCart, n, quantity);

    Console.WriteLine("continue yn");
    string yn = Console.ReadLine();
    if (yn != "y")
    {
        reciept.DisplayTotal(shoppingCart);
        break;
    }
}