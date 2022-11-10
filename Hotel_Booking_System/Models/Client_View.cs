using Hotel_Booking_System_DBContext.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel_Booking_System.Models
{
    public class Client_View
    {
        public int id { get; set; }
        public string client_name_ar { get; set; }
        public string client_name_en { get; set; }
        public string cell_namber { get; set; }
        public string telephone { get; set; }
        public string client_identity_no { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirm_Password { get; set; }
        public bool password_not_confirm { get; set; }
        public int Success { get; set; }
        public IEnumerable<Client> clients { get; set; }
    }
}