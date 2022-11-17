using Onederus_giftshop;

var listOfGifts = new Menu();
listOfGifts.GiftList();

Console.WriteLine("Hello, welcome to the Onederful Gift Shop. Would you like to view the list of items for sale? (y/n)");
string menuReply = Console.ReadLine().ToLower();

if (menuReply == "y")
{
    listOfGifts.GiftList();
}

Console.WriteLine("Please enter the number for the item you wish to purchase.");



//string[] paymentType = new string[] { "Cash", "Check", "Card" };
//for (int i = 0; i < paymentType.Length; i++)
//{
//    int paymentNumber = i + 1;
//    Console.WriteLine($"{paymentNumber} {paymentType[i]}");
//}

//Console.WriteLine("Pleae select the payment type.");
//int userInput = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine($"You have selected {paymentType}.");
//Console.ReadKey();

//thinking we can move lines 18 - 28 into the payment class, already added in NinaTwo branch (Payment Class)


/////TestingPaymentMethods
//show test subtotal
double testsubTotal = 20.00;
Console.WriteLine($"Subtotal: {testsubTotal}");

//show tax for testing
Console.WriteLine($"Tax: {Payment.Tax}");

//show total due for testing
double testtotalDue = Payment.GetTotalCost(testsubTotal);
Console.WriteLine($"Grand Total: {testtotalDue}\n");

//selectPayment
int paymentSelected = Payment.SelectPaymentType(testtotalDue);

