using Hotel_Booking_System.Models;
using Hotel_Booking_System_DBContext.Models;
using System.Linq;
using System.Web.Mvc;

namespace Hotel_Booking_System.Controllers
{
    public class RoomController : Controller
    {
        Hotel_System_DBContext db;
        Room_View Room;
        // GET: Room
        public ActionResult Rooms()
        {
            db = new Hotel_System_DBContext();
            Room = new Room_View()
            {
                categories = db.Hotel_Categories.ToList(),
                floors = db.Floors.ToList(),
                //room = new Hotel_Booking_System_DBContext.Models.Room(),
                room_types = db.Room_Types.ToList(),
                rooms = (from rm in db.Rooms.DefaultIfEmpty()
                        from fr in db.Floors.Where(x=> x.id == rm.floor_id).DefaultIfEmpty()
                        from hc in db.Hotel_Categories.Where(x => x.id == fr.hotel_category_id).DefaultIfEmpty()
                        from rt in db.Room_Types.Where(x=> x.id == rm.room_type_id).DefaultIfEmpty()
                        select new Room_List
                        {
                            Discption = rm.description,
                            Floor = fr.floor_no,
                            Hotel_category = hc.location,
                            Room_No = rm.room_no,
                            Room_Type= rt.name_type
                        }
                        ).ToList(),
            };



            return View(Room);
        }

        [HttpPost]
        public ActionResult Rooms(Room_View room)
        {
            db = new Hotel_System_DBContext();

            room.categories = db.Hotel_Categories.ToList();
            room.floors = db.Floors.ToList();
            room.room_types = db.Room_Types.ToList();
            room.rooms = (from rm in db.Rooms.DefaultIfEmpty()
                              from fr in db.Floors.Where(x => x.id == rm.floor_id).DefaultIfEmpty()
                              from hc in db.Hotel_Categories.Where(x => x.id == fr.hotel_category_id).DefaultIfEmpty()
                              from rt in db.Room_Types.Where(x => x.id == rm.room_type_id).DefaultIfEmpty()
                              select new Room_List
                              {
                                  Discption = rm.description,
                                  Floor = fr.floor_no,
                                  Hotel_category = hc.location,
                                  Room_No = rm.room_no,
                                  Room_Type = rt.name_type
                              }
                      ).ToList();


            return View(room);
        }
    }
}