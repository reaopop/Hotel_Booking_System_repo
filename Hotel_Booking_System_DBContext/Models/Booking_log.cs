namespace Hotel_Booking_System_DBContext.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking_log
    {
        public int id { get; set; }

        public int? room_id { get; set; }

        public int? hotel_category_id { get; set; }

        public decimal amount { get; set; }

        public int booked_days { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }

        public bool is_active { get; set; }

        public int client_id { get; set; }

        public virtual Client Client { get; set; }

        public virtual Hotel_Categories Hotel_Categories { get; set; }

        public virtual Room Room { get; set; }
    }
}
