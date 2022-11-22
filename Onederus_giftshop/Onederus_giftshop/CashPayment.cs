
namespace Onederus_giftshop
{
    public class CashPayment :IPayment
    {

        public double CashTendered { get; set; }
        public double ChangeDue { get; set; }

        /*
        public double CashPay(double grandTotal)

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
        */



        public void GetPaymentInfo(double grandTotal)
        {
            bool cashEnough = false;


            while (cashEnough == false)
            {
                Console.WriteLine("Enter amount tendered:");
                CashTendered = InputValidation.IsDouble();

                if (CashTendered < grandTotal)
                {
                    Console.WriteLine("Not enough funds\n");

                    Console.WriteLine($"you need {grandTotal - CashTendered:c} more");
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

