
using Hotel_Booking_System_DBContext.Interfaces;
using Hotel_Booking_System_DBContext.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Booking_System_DBContext.Services
{
    class Clients_Services : iBaseService<Client>
    {
        public Client Entity { get; set; }
        public Hotel_System_DBContext DbContext { get; set; }
        public IEnumerable<Client> Entites { get; set; }

        #region Constractor
        public Clients_Services(Client entity)
        {
            Entity = entity;
            DbContext = new Hotel_System_DBContext();
        }

        public Clients_Services(IEnumerable<Client> entites)
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
            DbContext.Clients.Remove(Entity);
            DbContext.SaveChanges();
            return true;
        }

        public bool InsertOrUpdate()
        {
            // Conditions
            if (Entity.id == 0)
                DbContext.Clients.Add(Entity);
            else
                DbContext.Clients.Attach(Entity);

            // Results
            DbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Client> SelectAll()
        {
            return DbContext.Clients.ToList();
        }

        public Client SelectByID()
        {
            return DbContext.Clients.FirstOrDefault(x => x.id == Entity.id) ?? new Client();
        }
        #endregion

    }

}
