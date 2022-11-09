using Hotel_Booking_System.Models;
using Hotel_Booking_System_DBContext.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Booking_System.Controllers
{
    public class Booking_ReportController : Controller
    {
        Hotel_System_DBContext db;
        Booking_Report_View book_view;

        // GET: Booking_Report
        public ActionResult Booking_Report()
        {
            db = new Hotel_System_DBContext();
            book_view = new Booking_Report_View()
            {
                booking_Report_List = (from re in db.Booking_log.Where(x=> (Hotel_Booking_System_Lib.Static_Data.loginClient_id == 0?x.id != 0:x.client_id == Hotel_Booking_System_Lib.Static_Data.loginClient_id )).DefaultIfEmpty()
                                       from client in db.Clients.Where(x => x.id == re.client_id).DefaultIfEmpty()
                                       from room in db.Rooms.Where(x => x.id == re.room_id).DefaultIfEmpty()
                                       from room_type in db.Room_Types.Where(x => x.id == room.room_type_id).DefaultIfEmpty()
                                       from floor in db.Floors.Where(x => x.id == room.floor_id).DefaultIfEmpty()
                                       from hotel_category in db.Hotel_Categories.Where(x => x.id == re.hotel_category_id).DefaultIfEmpty()
                                       select new Booking_Report_class
                                       {
                                           Client_Name = client.client_name_en,
                                           Hotel_Category = hotel_category.location,
                                           Total_Price = re.amount.ToString(),
                                           Room_no = room.room_no,
                                           Room_Type = room_type.name_type,
                                           Total_Price_After_Discount = re.amount.ToString(),//TODO Calculate Discount If Client have any booking before this booking
                                           Avaliability = (re.is_active == true ? "Available" : "Not Available")
                                       }).ToList(),
            };

            return View(book_view);
        }
    }
}