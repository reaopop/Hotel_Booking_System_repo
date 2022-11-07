
using Hotel_Booking_System_DBContext.Interfaces;
using Hotel_Booking_System_DBContext.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Booking_System_DBContext.Services
{
    class Hotel_Categories_Services : iBaseService<Hotel_Categories>
    {
        public Hotel_Categories Entity { get; set; }
        public Hotel_System_DBContext DbContext { get; set; }
        public IEnumerable<Hotel_Categories> Entites { get; set; }

        #region Constractor
        public Hotel_Categories_Services(Hotel_Categories entity)
        {
            Entity = entity;
            DbContext = new Hotel_System_DBContext();
        }

        public Hotel_Categories_Services(IEnumerable<Hotel_Categories> entites)
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
            DbContext.Hotel_Categories.Remove(Entity);
            DbContext.SaveChanges();
            return true;
        }

        public bool InsertOrUpdate()
        {
            // Conditions
            if (Entity.id == 0)
                DbContext.Hotel_Categories.Add(Entity);
            else
                DbContext.Hotel_Categories.Attach(Entity);

            // Results
            DbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Hotel_Categories> SelectAll()
        {
            return DbContext.Hotel_Categories.ToList();
        }

        public Hotel_Categories SelectByID()
        {
            return DbContext.Hotel_Categories.FirstOrDefault(x => x.id == Entity.id) ?? new Hotel_Categories();
        }
        #endregion

    }

}
