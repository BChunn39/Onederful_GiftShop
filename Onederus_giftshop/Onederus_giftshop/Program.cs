string[] paymentType = new string[] { "Cash", "Check", "Card" };
for (int i = 0; i < paymentType.Length; i++)
{
    int paymentNumber = i + 1;
    Console.WriteLine($"{paymentNumber} {paymentType[i]}");
}


Console.WriteLine("Pleae select the payment type.");
int userInput = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"You have selected {paymentType}.");
Console.ReadKey();
