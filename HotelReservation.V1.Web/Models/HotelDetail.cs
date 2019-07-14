using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservation.V1.Web.Models
{
    public class HotelDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string ImagePath { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }
      //  public List<string> Type { get; set; }
    }
}