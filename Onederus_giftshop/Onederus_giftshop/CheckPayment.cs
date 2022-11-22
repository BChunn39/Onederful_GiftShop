namespace Onederus_giftshop
{
    public class CheckPayment: IPayment
    {
        const int validCheckNumLength = 3;
        public int CheckNum { get; set; }

        public void GetCheckNumber()
        {
            bool validCheckNum = false;

            while (validCheckNum == false)
            {
                Console.WriteLine("Enter 3 digit check number:");

                int checkNumber = InputValidation.IsInt();

                int checkNumLength = CheckNum.ToString().Length;

                if (checkNumLength != validCheckNumLength)
                {
                    validCheckNum = false;
                }
                else
                {
                    validCheckNum = true;
                    CheckNum = checkNumber;
                }
            }
        }

        public void GetPaymentInfo(double grandTotal)
        {   
            GetCheckNumber();
        }
    }
}