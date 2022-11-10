using Hotel_Booking_System_DBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Booking_System.Models
{
    public class BookingLog_View
    {
        public int id { get; set; }
        public int client_id { get; set; }
        public int room_id { get; set; }
        public int room_type { get; set; }
        public int category_id { get; set; }
        public decimal amount { get; set; }
        public decimal amount_after_discount { get; set; }
        public string discount { get; set; }
        public DateTime check_in { get; set; }
        public DateTime check_out { get; set; }
        public bool single { get; set; }
        public bool double_ { get; set; }
        public bool suit { get; set; }
        public bool isActive { get; set; }
        public int Success { get; set; }
        public IEnumerable<Client> clients { get; set; }
        public IEnumerable<Hotel_Categories> categories { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Room_Types> room_types { get; set; }
    }
}