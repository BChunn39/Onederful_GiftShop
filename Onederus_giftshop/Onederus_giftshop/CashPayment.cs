namespace Onederus_giftshop
{
    public static class CashPayment
    {

        public static double CashTendered { get; set; }
        public static double ChangeDue { get; set; }

        public static double CashPay(double grandTotal)
        {
            CashTendered = 0.00;
            ChangeDue = Math.Round((CashTendered - grandTotal), 2, MidpointRounding.AwayFromZero);
            bool cashEnough = false;

            while (cashEnough == false)
            {
                Console.WriteLine("Enter amount tendered:");
                CashTendered = InputValidation.IsDouble();

                if (CashTendered < grandTotal)
                {
                    Console.WriteLine("Not enough funds\n");
                }
                else cashEnough = true;
            }
            return ChangeDue;
        }

    }
}
