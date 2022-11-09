
using Hotel_Booking_System_DBContext.Interfaces;
using Hotel_Booking_System_DBContext.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Booking_System_DBContext.Services
{
    public class booking_log_services : iBaseService<Booking_log>
    {
        public Booking_log Entity { get; set; }
        public Hotel_System_DBContext DbContext { get; set; }
        public IEnumerable<Booking_log> Entites { get; set; }

        #region Constractor
        public booking_log_services(Booking_log entity)
        {
            Entity = entity;
            DbContext = new Hotel_System_DBContext();
        }

        public booking_log_services(IEnumerable<Booking_log> entites)
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
            DbContext.Booking_log.Remove(Entity);
            DbContext.SaveChanges();
            return true;
        }

        public bool InsertOrUpdate()
        {
            // Conditions
            if (Entity.id == 0)
                DbContext.Booking_log.Add(Entity);
            else
                DbContext.Booking_log.Attach(Entity);

            // Results
            DbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Booking_log> SelectAll()
        {
            return DbContext.Booking_log.ToList();
        }

        public Booking_log SelectByID()
        {
            return DbContext.Booking_log.FirstOrDefault(x => x.id == Entity.id) ?? new Booking_log();
        }
        #endregion

    }

}
