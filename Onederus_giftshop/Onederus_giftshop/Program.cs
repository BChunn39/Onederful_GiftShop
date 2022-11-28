using Onederus_giftshop;

Menu menu = new Menu();
Register reciept = new Register();
List<GiftProduct> shoppingCart = new List<GiftProduct>();
menu.GiftList();

Console.WriteLine("Hello, welcome to the Onederful Gift Shop!\n Would you like to view the list of items for sale? (y/n)");
string menuReply = InputValidation.IsString(Console.ReadLine());

if (menuReply == "y")
{
    menu.DisplayGiftShopList();
}
while (true)
{
    Console.WriteLine("Please enter the number for the item you wish to purchase.");
    int n = InputValidation.IsInt();

    Console.WriteLine("How many would you like to purchase?");
    double quantity = InputValidation.IsDouble();
    menu.GetLineTotal(n, quantity);
    menu.AddToCart(shoppingCart, n, quantity);

    Console.WriteLine("continue yn");
    string yn = InputValidation.IsString(Console.ReadLine());
    if (yn != "y")
    {
        reciept.DisplayTotal(shoppingCart);
        break;
    }
}