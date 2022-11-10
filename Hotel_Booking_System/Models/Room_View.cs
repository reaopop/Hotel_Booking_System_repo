using Hotel_Booking_System_DBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Booking_System.Models
{
    public class Room_View
    {
        public int id { get; set; }

        public int Hotel_Category_id { get; set; }
        public IEnumerable<Hotel_Categories> categories { get; set; }

        public int floor_id { get; set; }
        public IEnumerable<Floor> floors { get; set; }


        public int room_type_id { get; set; }
        public IEnumerable<Room_Types> room_types { get; set; }

        public string room_no { get; set; }
        public decimal day_price { get; set; }
        public string description { get; set; }
        public int Success { get; set; }

        public IEnumerable<Room_List> rooms { get; set; }
    }
    public class Room_List
    {
        public string Hotel_category { get; set; }
        public string Room_No { get; set; }
        public string Floor { get; set; }
        public string Room_Type { get; set; }
        public string Discption { get; set; }
    }
}