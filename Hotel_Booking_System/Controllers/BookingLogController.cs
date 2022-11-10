using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_Booking_System.Models;
using Hotel_Booking_System_DBContext.Models;

namespace Hotel_Booking_System.Controllers
{
    public class BookingLogController : Controller
    {
        Hotel_System_DBContext db;
        BookingLog_View booking;
        // GET: BookingLog
        public ActionResult BookingLog()
        {
            db = new Hotel_System_DBContext();
            booking = new BookingLog_View()
            {
                discount = "",
                clients = db.Clients.ToList(),
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
        public ActionResult BookingLog(BookingLog_View book)
        {
            db = new Hotel_System_DBContext();
            int HaveDiscount = db.Booking_log.Where(x => x.client_id == book.client_id).Count();
            book.amount = db.Rooms.FirstOrDefault(x => x.id == book.room_id).day_price * Convert.ToInt32((book.check_out - book.check_in).TotalDays);
            book.discount = HaveDiscount > 0 ? "95%" : "";
            book.amount_after_discount = book.amount - Hotel_Booking_System_Lib.Price_Calculation.GetDiscountValue(Convert.ToDecimal(0.95), book.amount);
            Hotel_Booking_System_DBContext.Services.booking_log_services service = new Hotel_Booking_System_DBContext.Services.booking_log_services(new Booking_log()
            {
                amount = book.amount,
                amount_after_discount = book.amount_after_discount,
                discount_price = Convert.ToDecimal(0.95),
                booked_days = Convert.ToInt32((book.check_out - book.check_in).TotalDays),
                client_id = book.client_id,
                end_date = book.check_out,
                start_date = book.check_in,
                hotel_category_id = book.category_id,
                is_active = book.isActive,
                room_id = book.room_id
            }) ;

            service.InsertOrUpdate();
            book.clients = db.Clients.ToList();
            book.categories = db.Hotel_Categories.ToList();
            book.Rooms = db.Rooms.ToList();
            book.room_types = db.Room_Types.ToList();
            book.Success = 1;

            return View(book);
        }
    }
}