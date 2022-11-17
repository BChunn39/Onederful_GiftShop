using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onederus_giftshop
{
    public static class Payment//Total /// should this be static? don't think they need to create another payment object, so it should probably be static
    {
        //not sure if all of these fields should be static...
        private static double subTotal;
        private static double tax;
        private static double grandTotal;


        public static double SubTotal { get; set; }
        public static double Tax { get; set; } = .06;
        public static double GrandTotal { get; set; }
        //public static bool isCashPay { get; set; }, was playing with these isXPays for testing
        //public static bool isCheckPay { get; set; }
        //public static bool isCardPay { get; set; }  


        //public Payment(double subTotal, double tax, double grandTotal)
        //{
        //    SubTotal = subTotal;
        //    Tax = tax;
        //    GrandTotal = grandTotal;
        //}

        public static double GetTotalCost(double SubTotal)
        {
            double subTotal = SubTotal;
            double tax = subTotal * .06;
            double grandTotal = Math.Round((subTotal + tax), 2, MidpointRounding.AwayFromZero); // NEED TO ADD THIS

            return grandTotal;
        }


        public static int SelectPaymentType(double totalDue)
        {
            string[] paymentOptions = new string[] { "Cash", "Check", "Card" };

            for (int i = 0; i < paymentOptions.Length; i++)
            {
                int paymentNumber = i + 1;
                Console.WriteLine($"{paymentNumber} {paymentOptions[i]}");
            }

            Console.WriteLine("Please enter the number of selected payment type");
            int paymentType = Convert.ToInt32(Console.ReadLine());

            switch (paymentType) // if 1 - cash, if 2 - check, if 3 - card
            {
                case 1:
                    CashPayment(totalDue);
                    break;
                case 2:
                    CheckPayment(totalDue);
                    break;
                case 3:
                    CardPayment(totalDue);
                    break;
            }
            return -1;
        }


        public static double CashPayment(double grandTotal)
        {
            double cashTendered = ValidateAmountGivenCoversGrandTotal(grandTotal);

            if (cashTendered > grandTotal)
            {
                double changeDue = cashTendered - grandTotal;
                Console.WriteLine($"Change Due: {changeDue}");
                return changeDue;
            }
            else return cashTendered;
        }

        public static bool CheckPayment(double grandTotal)
        {
            double checkTendered = ValidateAmountGivenCoversGrandTotal(grandTotal);

            //will need to do a loop for each of these sections
            Console.WriteLine("Enter check number:");
            int checkNumber = int.Parse(Console.ReadLine().Trim());
            //if < 4 numbers
            // if no numeric entry
            Console.WriteLine($"Is check amount for {grandTotal}?");
            string checkAmtCoversCost = (Console.ReadLine());
            // if amount is not equal to subtotal
            // if not a y or n response

            return true; // if all of that was successful

        }

        public static bool CardPayment(double grandTotal)
        {
            // will need to do a loop for each of these sections
            Console.WriteLine("Enter credit card number:");
            int creditCardNumber = int.Parse(Console.ReadLine().Trim());
            // will want to remove whitespace,
            // add if logic to handle number more or less than 16 digits, 
            // add logic to handle non numberic entries

            Console.WriteLine("Enter expiration date:");
            DateTime cardExpiration = DateTime.Parse(Console.ReadLine());
            //if mm/yy is < current date
            //how to handle year and month formatting....
            // if non numeric entry

            Console.WriteLine("Enter CVV:");
            int cvv = int.Parse(Console.ReadLine());
            // if < or > 3 digits
            // if nonnumeric entry

            return true; //if all of that is successful
        }
        // do we want the option to do split payments if they don't have enough money or check is not for full amount, oooorrrr do we want to to offer them the option to use another form of tender


        public static double ValidateAmountGivenCoversGrandTotal(double grandTotal)
        {
            bool isAmountDouble = false;
            bool amountCoversTotalDue = false;
            double amountTendered = 0;

            do
            {
                Console.WriteLine("Enter amount tendered:");
                isAmountDouble = double.TryParse(Console.ReadLine(), out amountTendered);

                if (isAmountDouble == false)
                {
                    Console.WriteLine("Invalid input. Please enter a valid amount.\n");
                }
                else if (isAmountDouble == true && amountTendered < grandTotal)
                {
                    Console.WriteLine("Tender amount less than amount due.\n");
                    //... meh, could do this - return -1; // when catching method in program, if -1, tell the user they need more money, or give them option to try another payment method
                }
                if (isAmountDouble == true && amountTendered > grandTotal)
                {
                    amountCoversTotalDue = true;
                    return amountTendered;
                }
            }
            while (amountCoversTotalDue == false);
            return amountTendered;
        }
    }
 

}
