using System;
using System.Collections.Generic;

namespace Onederus_giftshop
{
    public class Register
    {
        public double SubTotal { get; private set; }
        public const double TaxAmount = .06;
        public double Tax { get; private set; }
        public double GrandTotal { get; private set; }
        const string WindowsFilePath = @"C:\Stuff\Onderousreceipt.txt";
        const string MacFilePath = @"/Users/anh/Desktop/Test/Onderousreceipt1.txt";

        public void GetTotalCost(List<GiftProduct> cart)
        {
            SubTotal = cart.Sum(x => x.Price);
            Tax = SubTotal * TaxAmount;
            GrandTotal = Math.Round((SubTotal + Tax), 2, MidpointRounding.AwayFromZero);
        }

        public void DisplayPayTypes() // displaying pay options, being called by SelectPaymentType method
        {
            string[] paymentOptions = new string[] { "Cash", "Check", "Card" };

            for (int i = 0; i < paymentOptions.Length; i++)
            {
                int paymentNumber = i + 1;
                Console.WriteLine($"{paymentNumber} {paymentOptions[i]}");
            }
        }

        public void SelectPaymentType(List<GiftProduct> cart)
        {
            int payType = 0;
            bool isValidPayOpt = false;

            while (isValidPayOpt == false)
            {
                Console.WriteLine("\nPlease enter the number of selected payment type:");
                payType = InputValidation.IsInt();

                if (payType >= 1 && payType <= 3)
                {
                    isValidPayOpt = true;
                    switch (payType)
                    {
                        case 1:
                            CashPayment cash = new CashPayment();
                            cash.GetPaymentInfo(GrandTotal);
                            Console.Clear();
                            PrintReceipt(cart, cash);
                            break;

                        case 2:
                            CheckPayment check = new CheckPayment();
                            AcceptAmountDueForNonCashPayment(GrandTotal, cart);
                            check.GetPaymentInfo(GrandTotal);
                            Console.Clear();
                            PrintReceipt(cart, check);
                            break;

                        case 3:
                            CardPayment card = new CardPayment();
                            AcceptAmountDueForNonCashPayment(GrandTotal, cart);
                            card.GetPaymentInfo(GrandTotal);
                            Console.Clear();
                            PrintReceipt(cart, card);
                            break;

                        default:
                            throw new ArgumentOutOfRangeException("Unknown value");
                    }
                }
            }
        }

        public bool AcceptAmountDueForNonCashPayment(double grandTotal, List<GiftProduct> cart)
        {
            bool tenderAccept = false;

            while (tenderAccept == false)
            {
                Console.WriteLine($"\nTo process your payment for {GrandTotal}: Press 'y'.");
                Console.WriteLine("To select a different payment method: Press 'n'.");
                Console.WriteLine("To stop shopping and exit the program: Press any other key.");

                string processTransaction = InputValidation.IsString(Console.ReadLine());

                if (processTransaction == "y")
                {
                    tenderAccept = true;
                    break;
                }
                if (processTransaction == "n")
                {
                    SelectPaymentType(cart);
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

        // display credit card receipt
        public string DisplayPayment(CardPayment card)
        {
            return $"{GrandTotal:c} paid with credit card #{card.LastFour}\n";
        }
        // display check on receipt
        public string DisplayPayment(CheckPayment check)
        {
            return $"{GrandTotal:c} paid with check #{check.CheckNum}\n";
        }
        // display cash receipt
        public string DisplayPayment(CashPayment cash)
        {
            return $"{GrandTotal:c} paid with {cash.CashTendered:c} cash. Change due is {cash.ChangeDue:C}\n";
        }

        public void Displayreceipt(List<GiftProduct> cart)
        {
            Console.Clear();
            foreach (GiftProduct item in cart)
            {
                Console.WriteLine(String.Format("{0,-10} | {1,-10}", $"{item.Name}", $"{item.Price:c}"));
            }
            Console.WriteLine(String.Format("{0,15} {1,-10}", $"Subtotal", $"{SubTotal:c}"));
            Console.WriteLine(String.Format("{0,15} {1,-10}", $"Tax", $"{Tax:c}"));
            Console.WriteLine(String.Format("{0,15} {1,-10}", $"Total", $"{GrandTotal:c}"));
        }

        public void DisplayTotal(List<GiftProduct> cart)
        {
            GetTotalCost(cart);
            Displayreceipt(cart);
            DisplayPayTypes();
            SelectPaymentType(cart);
        }

        public void PrintReceipt(List<GiftProduct> cart, CardPayment payment)
        {
            string print = InputValidation.IsString(Console.ReadLine());
            if (print == "y" || print == "yes")
            {
                StreamWriter receiptWriter = new StreamWriter(WindowsFilePath, false);
                foreach (GiftProduct item in cart)
                {
                    receiptWriter.WriteLine(String.Format("{0,-10} | {1,-10}", $"{item.Name}", $"{item.Price:c}"));
                }
                receiptWriter.WriteLine(String.Format("{0,15} {1,-10}", $"Subtotal", $"{SubTotal:c}"));
                receiptWriter.WriteLine(String.Format("{0,15} {1,-10}", $"Tax", $"{Tax:c}"));
                receiptWriter.WriteLine(String.Format("{0,15} {1,-10}", $"Total", $"{GrandTotal:c}"));
                receiptWriter.Flush();
                receiptWriter.Close();
            }
            else
            {
                Displayreceipt(cart);
                Console.WriteLine(DisplayPayment(payment));
            }
        }
        
        public void PrintReceipt(List<GiftProduct> cart, CheckPayment payment)
        {
            Console.WriteLine("Would you like a printed copy of your receipt?");
            string print = InputValidation.IsString(Console.ReadLine());
            if (print == "y" || print == "yes")
            {
                StreamWriter receiptWriter = new StreamWriter(WindowsFilePath, false);
                foreach (GiftProduct item in cart)
                {
                    receiptWriter.WriteLine(String.Format("{0,-10} | {1,-10}", $"{item.Name}", $"{item.Price:c}"));
                }
                receiptWriter.WriteLine(String.Format("{0,15} {1,-10}", $"Subtotal", $"{SubTotal:c}"));
                receiptWriter.WriteLine(String.Format("{0,15} {1,-10}", $"Tax", $"{Tax:c}"));
                receiptWriter.WriteLine(String.Format("{0,15} {1,-10}", $"Total", $"{GrandTotal:c}"));
                receiptWriter.Flush();
                receiptWriter.Close();
            }
            else
            {
                Displayreceipt(cart);
                Console.WriteLine(DisplayPayment(payment));
            }
        }

        public void PrintReceipt(List<GiftProduct> cart, CashPayment payment)
        {
            Console.WriteLine("Would you like a printed copy of your receipt?");
            string print = InputValidation.IsString(Console.ReadLine());
            if (print == "y" || print == "yes")
            {
                StreamWriter receiptWriter = new StreamWriter(WindowsFilePath, false);
                foreach (GiftProduct item in cart)
                {
                    receiptWriter.WriteLine(String.Format("{0,-10} | {1,-10}", $"{item.Name}", $"{item.Price:c}"));
                }
                receiptWriter.WriteLine(String.Format("{0,15} {1,-10}", $"Subtotal", $"{SubTotal:c}"));
                receiptWriter.WriteLine(String.Format("{0,15} {1,-10}", $"Tax", $"{Tax:c}"));
                receiptWriter.WriteLine(String.Format("{0,15} {1,-10}", $"Total", $"{GrandTotal:c}"));
                receiptWriter.Flush();
                receiptWriter.Close();
            }
            else
            {
                Displayreceipt(cart);
                Console.WriteLine(DisplayPayment(payment));
            }
        }
    }
}
