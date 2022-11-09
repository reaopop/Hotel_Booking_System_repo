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
    public class ClientsController : Controller
    {

        Hotel_System_DBContext db;
        Client_View client;
        // GET: Room
        public ActionResult Clients()
        {
            db = new Hotel_System_DBContext();
            client = new Client_View()
            {
                clients = db.Clients.ToList(),
            };



            return View(client);
        }

        [HttpPost]
        public ActionResult Clients(Client_View client)
        {
            db = new Hotel_System_DBContext();
            Clients_Services service = new Clients_Services(new Hotel_Booking_System_DBContext.Models.Client()
            {
                cell_namber = client.cell_namber,
                client_identity_no = client.client_identity_no,
                client_name_ar = client.client_name_ar,
                client_name_en = client.client_name_en,
                Email = client.Email,
                id = client.id,
                Password = client.Password,
                telephone = client.telephone,

            });
            service.InsertOrUpdate();

            client.clients = db.Clients.ToList();
           

            return View(client);
        }
        
    }
}