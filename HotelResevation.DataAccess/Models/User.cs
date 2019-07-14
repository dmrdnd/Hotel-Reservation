﻿using System;
using System.Collections.Generic;

namespace HotelReservation.V1.Web
{
    public partial class User
    {
        public User()
        {
            HotelComment = new HashSet<HotelComment>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public virtual ICollection<HotelComment> HotelComment { get; set; }
    }
}
