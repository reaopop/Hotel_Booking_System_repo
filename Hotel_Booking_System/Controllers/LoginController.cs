using Hotel_Booking_System.Models;
using Hotel_Booking_System_DBContext.Models;
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
        LoginView loginview;
        // GET: Login
        public ActionResult Login()
        {
            db = new Hotel_System_DBContext();
            loginview = new LoginView() { client = new Client() };
            return View(loginview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Client objUser)
        {
            if (ModelState.IsValid)
            {
               
                    var obj = db.Clients.Where(a => a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["Email"] = obj.Email.ToString();
                        return RedirectToAction("User_Book" , "Home");
                    }
            }
            return View(objUser);
        }
    }
}