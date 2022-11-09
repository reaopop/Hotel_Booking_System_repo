using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Booking_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
     
       
        public ActionResult Reservation_Results()
        {
            ViewBag.Message = "Your booking page.";

            return View();
        }
        public ActionResult Rooms()
        {
            ViewBag.Message = "Your booking page.";

            return View();
        }
        public ActionResult Booking_Report()
        {
            ViewBag.Message = "Your booking page.";

            return View();
        }
        public ActionResult User_Book()
        {
            ViewBag.Message = "Your booking page.";

            return View();
        }
        //public ActionResult Login()
        //{
        //    ViewBag.Message = "Your booking page.";

        //    return View();
        //}


    }
}