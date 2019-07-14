using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.DataAccess.IRepository
{
    public interface IHotel<T>
    {
        T Get(int id);
        List<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
