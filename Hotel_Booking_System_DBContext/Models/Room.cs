namespace Hotel_Booking_System_DBContext.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            Booking_log = new HashSet<Booking_log>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string room_no { get; set; }

        public int floor_id { get; set; }

        public int room_type_id { get; set; }

        public bool is_avaliable { get; set; }
        public string description { get; set; }

        [Required]
        public decimal day_price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking_log> Booking_log { get; set; }

        public virtual Floor Floor { get; set; }

        public virtual Room_Types Room_Types { get; set; }
    }
}
