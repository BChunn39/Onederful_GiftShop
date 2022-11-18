
using Onederus_giftshop;

Menu menu = new Menu();
menu.GiftList();

Console.WriteLine("Hello, welcome to the Onederful Gift Shop. Would you like to view the list of items for sale? (y/n)");
string menuReply = Console.ReadLine().ToLower();

if (menuReply == "y")
{
    menu.DisplayGiftShopList();

    menu.GetLineTotal();
}
else Console.WriteLine("Thank you, come again!");

