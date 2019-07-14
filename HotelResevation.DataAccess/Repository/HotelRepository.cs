using HotelReservation.DataAccess.IRepository;
using HotelReservation.V1.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservation.DataAccess.Repository
{
    public class HotelRepository : IHotel<Hotel>
    {
        HoteldbContext dc = new HoteldbContext();
        Hotel hotel = new Hotel();

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Hotel Get(int id)
        {        
            throw new NotImplementedException();
        }

        public List<Hotel> GetAll()
        {
            List<Hotel> lists = dc.Hotel.ToList();
            // List<Hotel> list = dc.Hotel.Where(c => c.Name == "Palmin Hotel").FirstOrDefault();
            return lists;       
        }

        public void Insert(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Hotel entity)
        {
            throw new NotImplementedException();
        }
    }
}
