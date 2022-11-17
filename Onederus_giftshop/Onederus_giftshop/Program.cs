using Onederus_giftshop;

///Moved this logic to new Payment class, wanted to talk through with the team
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

///Testing Methods in Payment Class
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

