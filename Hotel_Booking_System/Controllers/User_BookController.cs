using Hotel_Booking_System.Models;
using Hotel_Booking_System_DBContext.Models;
using Hotel_Booking_System_DBContext.Services;
using System;
using System.Linq;
using System.Web.Mvc;


namespace Hotel_Booking_System.Controllers
{
    public class User_BookController : Controller
    {
        Hotel_System_DBContext db;
        BookingLog_View booking;
        // GET: User_Book
        public ActionResult User_Book()
        {
            db = new Hotel_System_DBContext();
            booking = new BookingLog_View()
            {
                clients = db.Clients.Where(x => (Hotel_Booking_System_Lib.Static_Data.loginClient_id == 0 ? x.id != 0 : x.id == Hotel_Booking_System_Lib.Static_Data.loginClient_id)).ToList(),
                categories = db.Hotel_Categories.ToList(),
                Rooms = db.Rooms.ToList(),
                room_types = db.Room_Types.ToList(),
                check_in = DateTime.Now,
                check_out = DateTime.Now,
                Success = 0,

            };
            return View(booking);
        }




        [HttpPost]
        public ActionResult User_Book(BookingLog_View book)
        {
            db = new Hotel_System_DBContext();
            book.client_id = Hotel_Booking_System_Lib.Static_Data.loginClient_id;
            
            Hotel_Booking_System_DBContext.Services.booking_log_services service = new Hotel_Booking_System_DBContext.Services.booking_log_services(new Booking_log()
            {
                amount = book.amount,
                booked_days = Convert.ToInt32((book.check_out - book.check_in).TotalDays),
                client_id = book.client_id,
                end_date = book.check_out,
                start_date = book.check_in,
                hotel_category_id = book.category_id,
                is_active = book.isActive,
                room_id = book.room_id,
                
            });

            service.InsertOrUpdate();
            book.Success = 1;
            book = new BookingLog_View()
            {
                clients = db.Clients.Where(x => (Hotel_Booking_System_Lib.Static_Data.loginClient_id == 0 ? x.id != 0 : x.id == Hotel_Booking_System_Lib.Static_Data.loginClient_id)).ToList(),
                categories = db.Hotel_Categories.ToList(),
                Rooms = db.Rooms.ToList(),
                room_types = db.Room_Types.ToList(),
                check_in = DateTime.Now,
                check_out = DateTime.Now

            };

            return View(book);
        }
    }
}