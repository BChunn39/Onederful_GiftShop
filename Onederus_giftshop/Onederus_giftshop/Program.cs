using Onederus_giftshop;


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
//int paymentSelected = Payment.SelectPaymentType(testtotalDue);

