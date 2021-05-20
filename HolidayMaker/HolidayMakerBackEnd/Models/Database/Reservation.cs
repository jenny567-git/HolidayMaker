﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace HolidayMakerBackEnd.Models.Database
{
    public partial class Reservation
    {
        public Reservation()
        {
            ReservedRooms = new HashSet<ReservedRoom>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public int? FlightId { get; set; }
        public int HotelId { get; set; }
        public int GuestId { get; set; }
        
        [JsonIgnore]
        public virtual Guest Guest { get; set; }
        [JsonIgnore]
        public virtual Hotel Hotel { get; set; }
        [JsonIgnore]
        public virtual ICollection<ReservedRoom> ReservedRooms { get; set; }
    }
}
