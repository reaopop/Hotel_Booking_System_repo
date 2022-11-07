

using Hotel_Booking_System_DBContext.Interfaces;
using Hotel_Booking_System_DBContext.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Booking_System_DBContext.Services
{
    public class Room_services : iBaseService<Room>
    {
        public Room Entity { get; set; }
        public Hotel_System_DBContext DbContext { get; set; }
        public IEnumerable<Room> Entites { get; set; }

        #region Constractor
        public Room_services(Room entity)
        {
            Entity = entity;
            DbContext = new Hotel_System_DBContext();
        }

        public Room_services(IEnumerable<Room> entites)
        {
            Entites = entites;
            DbContext = new Hotel_System_DBContext();
        }
        #endregion

        #region Methods
        public bool Delete()
        {
            // Conditions

            // Results
            DbContext.Rooms.Remove(Entity);
            DbContext.SaveChanges();
            return true;
        }

        public bool InsertOrUpdate()
        {
            // Conditions
            if (Entity.id == 0)
                DbContext.Rooms.Add(Entity);
            else
                DbContext.Rooms.Attach(Entity);

            // Results
            DbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Room> SelectAll()
        {
            return DbContext.Rooms.ToList();
        }

        public Room SelectByID()
        {
            return DbContext.Rooms.FirstOrDefault(x => x.id == Entity.id) ?? new Room();
        }
        #endregion

    }

}
