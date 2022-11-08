using Hotel_Booking_System_DBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Booking_System.Models
{
    public class Reservation_Result_view
    {
        public Nullable<int> client_id { get; set; }
        public IEnumerable<Client> clients { get; set; }
        public IEnumerable<Reservation_Result> results { get; set; }
    }
    public class Reservation_Result
    {
        public string client_name { get; set; }
        public string check_in { get; set; }
        public string check_out { get; set; }
        public string hotel_category { get; set; }
        public string floor { get; set; }
        public string room_no { get; set; }
        public string room_type { get; set; }
        public decimal total_price { get; set; }
    }
}