using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Booking_System_DBContext.Interfaces
{
    public interface IBase_Service<T>
    {
        T Entity { get; set; }
        void AddMessageParameters();
        void AddParameters();
        void AddParameterID();
        bool InsertOrUpdate();
        bool Delete();
        List<T> SelectAll();
        T SelectByID();
    }
    public interface iBaseService<T>
    {
        T Entity { get; set; }
        Hotel_Booking_System_DBContext.Models.Hotel_System_DBContext DbContext { get; set; }
        IEnumerable<T> Entites { get; set; }

        bool InsertOrUpdate();
        bool Delete();
        IEnumerable<T> SelectAll();
        T SelectByID();
    }
}
