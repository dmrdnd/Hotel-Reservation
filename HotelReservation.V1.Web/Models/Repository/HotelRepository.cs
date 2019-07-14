
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelReservation.V1.Web.Models.IRepository;
using HotelReservation.V1.Web.App_Data;
using HotelReservation.V1.Web.Models;

namespace HotelReservation.V1.Web.Models.Repository
{
    

    public class HotelRepository : IHotel<Hotel>
    {
        HoteldbContext hoteldbContext = new HoteldbContext();
        HotelDetail hoteldetail = new HotelDetail();
        ViewRoomType viewRoomType = new ViewRoomType();
        public List<HotelDetail> hotelDetail;

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<HotelDetail> Detail(int id)
        {
            List<Hotel> hotels = hoteldbContext.Hotel.ToList();
            HotelDetail hd = new HotelDetail();
            var hotelImage = hoteldbContext.HotelImage.Where(c => c.HotelId == id).Select(a => a.ImagePath).FirstOrDefault();
            var hotelComment = hoteldbContext.HotelComment.Where(c => c.HotelId == id).Select(a => a.Comment).FirstOrDefault();
            var hotelScore = hoteldbContext.HotelScore.Where(c => c.HotelId == id).Select(a => a.ScoreValue).FirstOrDefault(); 

            var hoteldetail = (from h in hoteldbContext.Hotel
                               join hA in hoteldbContext.HotelAddress on h.Id equals hA.HotelId into list1
                               from l1 in list1.DefaultIfEmpty()
                               join hC in hoteldbContext.HotelContact on h.Id equals hC.HotelId into list2
                               from l2 in list2.DefaultIfEmpty()
                               where h.Id == id
                               select new HotelDetail
                               {
                                   Id = h.Id,
                                   Name = h.Name,
                                   Address = l1.AddressText,
                                   Contact = l2.ContactValue,
                                   ImagePath = hotelImage,
                                   Comment=hotelComment,
                                   Score=(int)hotelScore
                               }).ToList();                
           
            return hoteldetail;
        }

        public List<HotelDetail> Get(string name)
        {
            //Hotel hotels = hoteldbContext.Hotel.Find(name);
            //Hotel hotel = hoteldbContext.Hotel.Where(c => c.Name == "name").FirstOrDefault();
            List<Hotel> hotels = hoteldbContext.Hotel.ToList();
           
           
            int hotelId = hoteldbContext.Hotel.Where(c => c.Name == name).Select(a => a.Id).FirstOrDefault();
            var hoteldetail = (from h in hoteldbContext.Hotel
                               join hA in hoteldbContext.HotelAddress on h.Id equals hA.HotelId into list1
                               from l1 in list1.DefaultIfEmpty()
                               join hC in hoteldbContext.HotelContact on h.Id equals hC.HotelId into list2
                               from l2 in list2.DefaultIfEmpty()
                               where h.Id==hotelId
                               select new HotelDetail
                               {
                                  Id = h.Id,
                                  Name = h.Name,
                                  Address = l1.AddressText,
                                  Contact = l2.ContactValue
                               }).ToList();

            return hoteldetail;
          
        }

        public List<Hotel> GetAll()
        {
            List<Hotel> lists = hoteldbContext.Hotel.ToList();
            // List<Hotel> list = dc.Hotel.Where(c => c.Name == "Palmin Hotel").FirstOrDefault();
            return lists;

        }
        public List<HotelRoomPrice> HotelPrice(int id)
        {
            //var type = hoteldbContext.HotelRoom.Where(c => c.HotelId == id).Select(m => m.RoomSummary).ToList();

            var hotelPrice = (from hR in hoteldbContext.HotelRoom
                              join hRP in hoteldbContext.HotelRoomPrice on hR.RoomTypeId equals hRP.HotelRoomId
                              where hR.RoomTypeId == id
                              select new HotelRoomPrice
                              {
                                   Id = hRP.Id,
                                   Price = hRP.Price,
                                   StartDate=hRP.StartDate,
                                   EndDate=hRP.EndDate                        
                               }).ToList();
            return hotelPrice;
        }

        public List<ViewRoomType> RoomType(int id)
        {           
                 var roomType = (from hR in hoteldbContext.HotelRoom
                                 join rT in hoteldbContext.RoomType on hR.RoomTypeId equals rT.Id
                                 where hR.HotelId == id
                                 select new ViewRoomType
                                 {
                                     RoomTypeId = (int)hR.RoomTypeId,
                                     RoomSummary = hR.RoomSummary,
                                     TypeName=rT.TypeName
                                 }).ToList();
            
            return roomType;
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