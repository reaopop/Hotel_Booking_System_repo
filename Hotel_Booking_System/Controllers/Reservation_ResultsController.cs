using Hotel_Booking_System.Models;
using Hotel_Booking_System_DBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Booking_System.Controllers
{
    public class Reservation_ResultsController : Controller
    {
        Hotel_System_DBContext db;
        Reservation_Result_view results;

        // GET: Reservation_Results
        public ActionResult Reservation_Results()
        {
            db = new Hotel_System_DBContext();
            results = new Reservation_Result_view();

            results.clients = db.Clients.Where(x => (Hotel_Booking_System_Lib.Static_Data.loginClient_id == 0 ? x.id != 0 : x.id == Hotel_Booking_System_Lib.Static_Data.loginClient_id)).ToList();

            results.results = (from re in db.Booking_log.Where(x => (Hotel_Booking_System_Lib.Static_Data.loginClient_id == 0 ? x.id != 0 :x.client_id == Hotel_Booking_System_Lib.Static_Data.loginClient_id)).DefaultIfEmpty()
                       from client in db.Clients.Where(x=> x.id == re.client_id).DefaultIfEmpty()
                       from room in db.Rooms.Where(x => x.id == re.room_id).DefaultIfEmpty()
                       from room_type in db.Room_Types.Where(x=> x.id == room.room_type_id).DefaultIfEmpty()
                       from floor in db.Floors.Where(x => x.id == room.floor_id).DefaultIfEmpty()
                       from hotel_category in db.Hotel_Categories.Where(x => x.id == re.hotel_category_id).DefaultIfEmpty()
                       select new Reservation_Result
                       {
                           check_in = re.start_date.ToString(),
                           check_out = re.end_date.ToString(),
                           client_name = client.client_name_en,
                           floor = floor.floor_no,
                           hotel_category = hotel_category.location,
                           room_no = room.room_no,
                           room_type = room_type.name_type,
                           total_price = re.amount
                       }).ToList();

            return View(results);
        }

        [HttpPost]
        public ActionResult Reservation_Results(Reservation_Result_view results)
        {
            db = new Hotel_System_DBContext();
            results.clients = db.Clients.ToList();

            results.results = (from re in db.Booking_log.Where(x => x.client_id == results.client_id.Value).DefaultIfEmpty()
                               from client in db.Clients.Where(x => x.id == re.client_id).DefaultIfEmpty()
                               from room in db.Rooms.Where(x => x.id == re.room_id).DefaultIfEmpty()
                               from room_type in db.Room_Types.Where(x => x.id == room.room_type_id).DefaultIfEmpty()
                               from floor in db.Floors.Where(x => x.id == room.floor_id).DefaultIfEmpty()
                               from hotel_category in db.Hotel_Categories.Where(x => x.id == re.hotel_category_id).DefaultIfEmpty()
                               select new Reservation_Result
                               {
                                   check_in = re.start_date.ToString(),
                                   check_out = re.end_date.ToString(),
                                   client_name = client.client_name_en,
                                   floor = floor.floor_no,
                                   hotel_category = hotel_category.location,
                                   room_no = room.room_no,
                                   room_type = room_type.name_type,
                                   total_price = re.amount
                               }).ToList();
            
            return View(results);
        }
    }
}