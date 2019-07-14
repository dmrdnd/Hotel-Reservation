
using HotelReservation.V1.Web.App_Data;
using HotelReservation.V1.Web.Models;
using HotelReservation.V1.Web.Models.Repository;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.Mvc;

namespace HotelReservation.V1.Web.Controllers
{
    public class HotelController : Controller
    {
        HotelRepository hotelRepository = new HotelRepository();
        // GET: Hotel
        public ActionResult Index()
        {
            var hotels = hotelRepository.GetAll();
            return View(hotels);
        }
        [HttpGet]
        public ActionResult Detail(int id) 
        {
            //string hotelName = form["name"].Trim();                       
            List<HotelDetail> hoteldetail=hotelRepository.Detail(id);
              if (hoteldetail == null)
              {
                  return HttpNotFound();
              }                       
            return View("Search",hoteldetail);
        }
    

        [HttpGet]
        public ActionResult Search(string name)
        {                
            List<HotelDetail> hoteldetail = hotelRepository.Get(name);
            if (name == null)
            {
                return HttpNotFound();
            }             
            return View(hoteldetail);
        }

        public ActionResult HotelPrice(int id)
        {
            List<HotelRoomPrice> hotelPrice = hotelRepository.HotelPrice(id);
            if (hotelPrice == null)
            {
                return HttpNotFound();
            }
            return View(hotelPrice);

        }
        public ActionResult RoomType(int id)
        {
            List<ViewRoomType> hoteltype = hotelRepository.RoomType(id);

            if (hoteltype == null)
            {
                return HttpNotFound();
            }                        
            return View(hoteltype);
        }

    }
}