namespace Hotel_Booking_System_DBContext.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hotel_Info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel_Info()
        {
            Hotel_Categories = new HashSet<Hotel_Categories>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name_ar { get; set; }

        [Required]
        [StringLength(255)]
        public string name_en { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hotel_Categories> Hotel_Categories { get; set; }
    }
}
