using Microsoft.VisualBasic;
using Onederus_giftshop;
using System;
using System.Data;
using System.Globalization;
using System.Xml.Linq;

namespace Onederus_giftshop
{
    public static class CardPayment
    {
        const int validCardLength = 16;
        const int validCvvLength = 3;
        const int validMonthLength = 2;
        const int validYearLength = 2;
        public static long CardNumber { get; set; }
        public static string CardExp { get; set; }
        public static int Cvv { get; set; }

        public static void CardPay(double totalDue) //calls all card validation methods
        {
            bool continueWithCard = Payment.NonCashTransaction(totalDue);
            GetCardNumber();
            GetCardExp();
            GetCardCvv();
        }

        public static long GetCardNumber()
        {
            bool validCardNum = false;

            while (validCardNum == false)
            {
                Console.WriteLine("\nEnter 16 digit credit card number:");
                CardNumber = InputValidation.IsLong();
                int cardNumLength = CardNumber.ToString().Length;

                if (cardNumLength != validCardLength)
                {
                    validCardNum = false;
                }
                else validCardNum = true;
            }
            return CardNumber;
        }

        public static string GetCardExp()
        {
            bool monthCaptured = false;
            bool yearCaptured = false;
            int year = 00;
            int month = 00;

            while (monthCaptured == false)
            {
                Console.WriteLine("\nEnter expiration month (MM):");
                month = InputValidation.IsMonth();

                int monthLength = month.ToString().Length;

                if (monthLength != validMonthLength)
                {
                    monthCaptured = false;
                }
                else monthCaptured = true;
                break;
            }

            while (yearCaptured == false)
            {
                Console.WriteLine("\nEnter expiration year (YY):");
                year = InputValidation.IsYear();

                int yearLength = year.ToString().Length;

                if (yearLength != validYearLength)
                {
                    yearCaptured = false;
                }
                else yearCaptured = true;
                break;
            }

            string MM = month.ToString();
            string YY = year.ToString();
            CardExp = ($"{MM}/{YY}");

            return CardExp;
        }

        public static int GetCardCvv()
        {
            bool validCvv = false;

            while (validCvv == false)
            {
                Console.WriteLine("\nEnter 3 digit cvv:");
                Cvv = InputValidation.IsInt();
                int checkNumLength = Cvv.ToString().Length;

                if (checkNumLength != validCvvLength)
                {
                    validCvv = false;
                }
                else validCvv = true;
            }
            return Cvv;
        }
    }

}