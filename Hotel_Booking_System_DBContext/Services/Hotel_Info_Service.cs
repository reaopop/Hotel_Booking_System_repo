using Hotel_Booking_System_DBContext.Interfaces;
using Hotel_Booking_System_DBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Booking_System_DBContext.Services
{
    public class Hotel_Info_Service : iBaseService<Room_Types>
    {
        #region Properties
        public Room_Types Entity { get; set; }
        public IEnumerable<Room_Types> Entites { get ; set; }
        public Hotel_System_DBContext DbContext { get; set ; }

        #endregion

        #region Constractor
        public Hotel_Info_Service(Room_Types entity)
        {
            Entity = entity;
            DbContext = new Hotel_System_DBContext();
        }

        public Hotel_Info_Service(IEnumerable<Room_Types> entites)
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
            DbContext.Room_Types.Remove(Entity);
            DbContext.SaveChanges();
            return true;
        }

        public bool InsertOrUpdate()
        {
            // Conditions
            if (Entity.id == 0)
                DbContext.Room_Types.Add(Entity);
            else 
                DbContext.Room_Types.Attach(Entity);

            // Results
            DbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Room_Types> SelectAll()
        {
            return DbContext.Room_Types.ToList() ;
        }

        public Room_Types SelectByID()
        {
            return DbContext.Room_Types.FirstOrDefault(x=> x.id == Entity.id) ?? new Room_Types();
        }
        #endregion
    }
}
