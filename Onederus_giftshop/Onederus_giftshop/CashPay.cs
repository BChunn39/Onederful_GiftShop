using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onederus_giftshop
{
    public class CashPay
    {
        public decimal cashTendered { get; set; }
        public decimal changeDue { get; set; }

        public override void GetTotalCost()
        {
            GetTotalCost();
            if (paymentType == "Cash")
            {
                Console.WriteLine("Cash tendered:");
                cashTendered = decimal.Parse(Console.ReadLine());
                if (cashTendered > total) 
                {
                    changeDue = cashTendered - total;
                    Console.WriteLine($"Your change is {changeDue}");
                }
            }
        }
    
    }
}