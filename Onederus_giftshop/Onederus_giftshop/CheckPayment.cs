namespace Onederus_giftshop
{
    public static class CheckPayment
    {
        const int validCheckNumLength = 3;
        public static int CheckNum { get; set; }

        public static void CheckPay(double totalDue)
        {
            bool continueWithCheck = Payment.NonCashTransaction(totalDue);
            GetCheckNumber();
        }

        public static int GetCheckNumber()
        {
            bool validCheckNum = false;

            while (validCheckNum == false)
            {
                Console.WriteLine("Enter 3 digit check number:");
                CheckNum = InputValidation.IsInt();
                int checkNumLength = CheckNum.ToString().Length;

                if (checkNumLength != validCheckNumLength)
                {
                    validCheckNum = false;
                }
                else validCheckNum = true;
            }
            return CheckNum;
        }
    }
}