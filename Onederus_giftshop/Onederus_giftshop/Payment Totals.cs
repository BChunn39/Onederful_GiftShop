using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onederus_giftshop
{
    public class Payment_Totals
    {
        public override string GetTotalCost()
        {
            double SubTotal = 0;
            double Tax = SubTotal * .06;
            double grandTotal = SubTotal + Tax;


            return $"Your subtotal is {SubTotal: C} the tax about is {Tax: C} and the total is {grandTotal: C}.";
        }

    }
}
