using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Booking_System_Lib
{
    public class Price_Calculation
    {
        public static decimal GetDiscountValue(decimal discount_pre , decimal total)
        {
            // the default discount is 95%
            decimal Value = 0;
            Value = discount_pre * total;

            return Value;
        }
    }
}
