namespace Hotel_Booking_System_DBContext.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Booking_log = new HashSet<Booking_log>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string client_name_ar { get; set; }

        [StringLength(255)]
        public string client_name_en { get; set; }

        [StringLength(40)]
        public string cell_namber { get; set; }

        [StringLength(40)]
        public string telephone { get; set; }

        [StringLength(255)]
        public string client_identity_no { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Password { get; set; }
        
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking_log> Booking_log { get; set; }
    }
}
