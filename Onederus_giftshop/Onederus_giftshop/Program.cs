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

int paymentMethod = Payment.SelectPaymentType(testtotalDue);
Console.WriteLine($"Payment Method = {paymentMethod}");
// if 1 - cash, if 2 - check, if 3 - card

