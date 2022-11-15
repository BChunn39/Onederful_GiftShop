using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onederus_giftshop
{
    public  class CreditPay
    {
        public int creditCardNumber { get; set; }
        public DateTime cardExpiration { get; set; }
        public int cvv { get; set; }

        public override void GetTotal()
        {
            base.GetTotal();

            if (paymentMethod == "Credit Card")
            {
                Console.WriteLine("Enter credit card number:");
                creditCardNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter expiration date:");
                cardExpiration = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter CVV:");
                cvv = int.Parse(Console.ReadLine());
            }
        }
    }
}
