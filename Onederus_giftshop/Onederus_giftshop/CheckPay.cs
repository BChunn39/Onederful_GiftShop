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

        public override void GetTotal()
        {
            base.GetTotal();
            if (paymentMethod == "Check")
            {
                Console.WriteLine("Enter check number");
                checkNumber = int.Parse(Console.ReadLine());
            }
        }
    }
}