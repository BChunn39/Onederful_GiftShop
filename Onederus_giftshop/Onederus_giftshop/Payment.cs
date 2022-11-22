using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            grandTotal = Math.Round((subTotal + tax), 2, MidpointRounding.AwayFromZero);

            return grandTotal;
        }

        /// payment options and selection
        public static void DisplayPayTypes() // displaying pay options, being called by SelectPaymentType method
        {
            string[] paymentOptions = new string[] { "Cash", "Check", "Card" };

            for (int i = 0; i < paymentOptions.Length; i++)
            {
                int paymentNumber = i + 1;
                Console.WriteLine($"{paymentNumber} {paymentOptions[i]}");
            }
        }

        public static int SelectPaymentType(double totalDue) //passing through total due so that it can be passed to payment methods when selected
        {
            int payType = 0;
            bool isValidPayOpt = false;

            while (isValidPayOpt == false)
            {
                DisplayPayTypes();

                Console.WriteLine("\nPlease enter the number of selected payment type:");
                payType = InputValidation.IsInt();

                if (payType >= 1 && payType <= 3)
                {
                    isValidPayOpt = true;
                    switch (payType)
                    {
                        case 1:
                            CashPayment.CashPay(totalDue);
                            break;
                        case 2:
                            CheckPayment.CheckPay(totalDue);
                            break;
                        case 3:
                            CardPayment.CardPay(totalDue);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Unknown value");
                    }
                }
            }
            return payType;
        }

        public static bool NonCashTransaction(double totalDue)
        {
            bool tenderAccept = false;

            while (tenderAccept == false)
            {
                Console.WriteLine($"\nTo process your payment for {totalDue}: Press 'y'.");
                Console.WriteLine("To select a different payment method: Press 'n'.");
                Console.WriteLine("To stop shopping and quit the program: Press any other key.");

                string processTransaction = InputValidation.IsString(Console.ReadLine());

                if (processTransaction == "y")
                {
                    tenderAccept = true;
                    break;
                }
                if (processTransaction == "n")
                {
                    SelectPaymentType(totalDue);
                    break;
                }
                else
                {
                    Console.Write("Thanks for shopping!");
                    Environment.Exit(0);
                }
            }
            return tenderAccept;
        }
    }
}

