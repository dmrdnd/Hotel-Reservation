using HotelReservation.V1.Web.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.V1.Web.Models.IRepository
{
    public interface IHotel<T>    
    {
        List<HotelDetail> Get(string name);
        List<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
