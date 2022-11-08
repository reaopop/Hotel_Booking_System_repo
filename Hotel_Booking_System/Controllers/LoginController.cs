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
            db = new Hotel_System_DBContext();
            //Clients_Services clients_Services = new Clients_Services(new Client());
            var obj = db.Clients.Where(a => a.Email.Equals(cln.Email) && a.Password.Equals(cln.Password)).FirstOrDefault();
            if (obj != null)
            {
                Session["id"] = obj.id.ToString();
                Session["Email"] = obj.Email.ToString();
                return RedirectToAction("User_Book", "Home");
            }
            return View(cln);
        }
    }
}