using Hotel_Booking_System.Models;
using Hotel_Booking_System_DBContext.Models;
using Hotel_Booking_System_DBContext.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Booking_System.Controllers
{
    public class LoginController : Controller
    {
        Hotel_System_DBContext db;
        Client loginview;
        // GET: Login
        public ActionResult Login()
        {
            Hotel_Booking_System_Lib.Static_Data.Visiblty = false;
            Hotel_Booking_System_Lib.Static_Data.IsAdmin = false;
            db = new Hotel_System_DBContext();
            loginview = new Client();
            return View(loginview);
        }

        [HttpPost]
        public ActionResult Login(Client client)
        {
            Client cln = new Client();
            cln.Email = client.Email;
            cln.Password = client.Password;
            if(cln.Email == "admin" && cln.Password == "admin")
            {
                Hotel_Booking_System_Lib.Static_Data.Visiblty = true;
                Hotel_Booking_System_Lib.Static_Data.loginClient_id = 0;
                Hotel_Booking_System_Lib.Static_Data.IsAdmin = true;

                return RedirectToAction("BookingLog", "BookingLog");
            }
            db = new Hotel_System_DBContext();
            //Clients_Services clients_Services = new Clients_Services(new Client());
            var obj = db.Clients.Where(a => a.Email.Equals(cln.Email) && a.Password.Equals(cln.Password)).FirstOrDefault();
            if (obj != null)
            {
                Session["id"] = obj.id.ToString();
                Session["Email"] = obj.Email.ToString();
                Hotel_Booking_System_Lib.Static_Data.loginClient_id = obj.id;
                Hotel_Booking_System_Lib.Static_Data.Visiblty = true;
                Hotel_Booking_System_Lib.Static_Data.IsAdmin = false;

                return RedirectToAction("User_Book", "User_Book");
            }
            return View(cln);
        }
    }
}