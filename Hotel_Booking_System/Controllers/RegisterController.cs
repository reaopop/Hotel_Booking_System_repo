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
    public class RegisterController : Controller
    {

        Hotel_System_DBContext db;
        Client_View loginview;
        public ActionResult Register()
        {
            Hotel_Booking_System_Lib.Static_Data.Visiblty = false;
            Hotel_Booking_System_Lib.Static_Data.IsAdmin = false;
            db = new Hotel_System_DBContext();
            loginview = new Client_View();
            return View(loginview);
        }

        [HttpPost]
        public ActionResult Register(Client_View client)
        {
            db = new Hotel_System_DBContext();
            Clients_Services clients_Services = new Clients_Services(new Client()
            {
                cell_namber = "",
                client_identity_no = "",
                client_name_ar = client.client_name_en,
                client_name_en = client.client_name_en,
                Email = client.Email,
                Password = client.Password,
                telephone = "",
                id = client.id,
            }) ;
            //var obj = db.Clients.Where(a => a.Email.Equals(client.Email) && a.Password.Equals(client.Password)).FirstOrDefault();
            if(client.Password == client.Confirm_Password)
            {

                clients_Services.InsertOrUpdate();
                client.password_not_confirm = false;
                return RedirectToAction("Login", "Login");

            }
            else
            {
                client.password_not_confirm = true;
            }

            return View(client);
        }
    }
}