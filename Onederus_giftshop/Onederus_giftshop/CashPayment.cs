namespace Onederus_giftshop
{
    public class CashPayment : IPayment
    {
        public double CashTendered { get; set; }
        public double ChangeDue { get; set; }

        public void GetPaymentInfo(double grandTotal)
        {
            bool cashEnough = false;

            while (cashEnough == false)
            {
                Console.WriteLine("Enter amount tendered:");
                CashTendered = InputValidation.IsDouble();

                if (CashTendered < grandTotal)
                {
                    Console.WriteLine($"Amount cannot be less than {grandTotal:c}. Please re-enter.\n");
                }
                else
                {
                    cashEnough = true;
                    ChangeDue = Math.Round((CashTendered - grandTotal), 2, MidpointRounding.AwayFromZero);
                }
            }
        }
    }
}