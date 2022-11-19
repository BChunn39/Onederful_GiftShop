using Onederus_giftshop;

///Testing Methods in Payment Class
//show test subtotal


Console.WriteLine($"Subtotal: {testSubTotal}");

//show tax for testing
Console.WriteLine($"Tax: {Payment.Tax}");

//show total due for testing
double testtotalDue = Payment.GetTotalCost(testSubTotal);
Console.WriteLine($"Grand Total: {testtotalDue}\n");

//show mayment method (1 cash, 2 check, 3 card)
int paymentMethod = Payment.SelectPaymentType(testtotalDue);
Console.WriteLine($"Payment Method = {paymentMethod}\n");

//show cash parameters
Console.WriteLine($"Cash Tendered: {CashPayment.CashTendered}");
Console.WriteLine($"Change Due: {CashPayment.ChangeDue}\n");

//show card parameters
Console.WriteLine($"Card Number: {CardPayment.CardNumber}");
Console.WriteLine($"Card CVV: {CardPayment.Cvv}");
Console.WriteLine($"Card Exp: {CardPayment.CardExp}\n");

//show check parameters
Console.WriteLine($"Check Number:{CheckPayment.CheckNum}");