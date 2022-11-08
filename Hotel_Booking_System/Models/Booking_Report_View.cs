using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Booking_System.Models
{
    public class Booking_Report_View
    {
        public IEnumerable<Booking_Report_class> booking_Report_List { get; set; }
    }
    public class Booking_Report_class
    {
        public string Client_Name { get; set; }
        public string Hotel_Category { get; set; }
        public string Room_no { get; set; }
        public string Room_Type { get; set; }
        public string Total_Price { get; set; }
        public string Total_Price_After_Discount { get; set; }
        public string Avaliability { get; set; }
    }
}