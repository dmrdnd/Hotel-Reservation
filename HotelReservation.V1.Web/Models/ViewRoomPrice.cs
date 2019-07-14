using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservation.V1.Web.Models
{
    public class ViewRoomPrice
    {
        public double RoomPrice { get; set; }
        public DateTime StartData { get; set; }
        public DateTime EndData { get; set; }
       
    }
}