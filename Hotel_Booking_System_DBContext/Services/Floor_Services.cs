
using Hotel_Booking_System_DBContext.Interfaces;
using Hotel_Booking_System_DBContext.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Booking_System_DBContext.Services
{
    class Floor_Services : iBaseService<Floor>
    {
        public Floor Entity { get; set; }
        public Hotel_System_DBContext DbContext { get; set; }
        public IEnumerable<Floor> Entites { get; set; }

        #region Constractor
        public Floor_Services(Floor entity)
        {
            Entity = entity;
            DbContext = new Hotel_System_DBContext();
        }

        public Floor_Services(IEnumerable<Floor> entites)
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
            DbContext.Floors.Remove(Entity);
            DbContext.SaveChanges();
            return true;
        }

        public bool InsertOrUpdate()
        {
            // Conditions
            if (Entity.id == 0)
                DbContext.Floors.Add(Entity);
            else
                DbContext.Floors.Attach(Entity);

            // Results
            DbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Floor> SelectAll()
        {
            return DbContext.Floors.ToList();
        }

        public Floor SelectByID()
        {
            return DbContext.Floors.FirstOrDefault(x => x.id == Entity.id) ?? new Floor();
        }
        #endregion

    }

}
