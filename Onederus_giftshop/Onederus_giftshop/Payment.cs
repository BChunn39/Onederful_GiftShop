using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onederus_giftshop
{
    public class Payment
    {
        private static double subTotal;
        private static double tax;
        private static double grandTotal;

        public static double SubTotal { get; set; }
        public static double Tax { get; set; } = .06;
        public static double GrandTotal { get; set; }


        public static double GetTotalCost(double SubTotal)
        {
            double subTotal = SubTotal;
            double tax = subTotal * Tax;
            grandTotal = Math.Round((subTotal + tax), 2, MidpointRounding.AwayFromZero); // this should work

            return grandTotal;
        }

        public void SelectPaymentType(double totalDue) 
        {
            bool paymentOptionValid = false;
            string[] paymentOptions = new string[] { "Cash", "Check", "Card" };

            for (int i = 0; i < paymentOptions.Length; i++)
            {
                int paymentNumber = i + 1;
                Console.WriteLine($"{paymentNumber} {paymentOptions[i]}");
            }

            do
            {
                Console.WriteLine("Please enter the number of selected payment type");
                int paymentType = Convert.ToInt32(Console.ReadLine());

                if (paymentType >= 1 && paymentType <= 3)
                {
                    paymentOptionValid = true;
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
                }

            } while (paymentOptionValid == false);
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
            bool checkNumberValid = false;
            double checkTendered = ValidateAmountGivenCoversGrandTotal(grandTotal);

            do
            {
                Console.WriteLine("Enter check number:");
                int checkNumber = int.Parse(Console.ReadLine().Trim());
                //if < 4 numbers
                // if no numeric entry
            }
            while (checkNumberValid == false);

            return true; // if all of that was successful

        }

        public static bool CardPayment(double grandTotal)
        {
            int validCardNumLength = 16;
            int validCVVLength = 3;
            bool validCardNum = false;
            bool validCVV = false;

            // will need to do a loop for each of these sections

            do
            {
                Console.WriteLine("Enter credit card number (16 digits):");
                int CCinput = int.Parse(Console.ReadLine());

                int lengthCardInput = CCinput.ToString().Length;

                if (lengthCardInput == validCardNumLength)
                {
                    validCardNum = true;
                }
                else
                {
                    Console.WriteLine("Card number entered not long enough");
                    validCardNum = false;
                }
            }
            while (validCardNum == false);


            Console.WriteLine("Enter expiration date:");
            DateTime cardExpiration = DateTime.Parse(Console.ReadLine());
            //if mm/yy is < current date
            //how to handle year and month formatting....
            // if non numeric entry

            do
            {
                Console.WriteLine("Enter CVV (3 digits):");
                int cvvInput = int.Parse(Console.ReadLine());

                int lengthCVVInput = cvvInput.ToString().Length;

                if (lengthCVVInput == validCVVLength)
                {
                    validCVV = true;
                }
                else
                {
                    Console.WriteLine("CVV not long enough");
                    validCVV = false;
                }
            }
            while (validCVV == false);

            return true;
        }


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
                if (isAmountDouble == true && amountTendered >= grandTotal)
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
