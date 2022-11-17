using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onederus_giftshop
{
    public class CheckPay
    {
        public int checkNumber { get; set; }

        public override void GetTotalCost()
        {
            GetTotalCost();
            if (paymentType == "Check")
            {
                Console.WriteLine("Enter check number");
                checkNumber = int.Parse(Console.ReadLine());
            }
        }
    }
}