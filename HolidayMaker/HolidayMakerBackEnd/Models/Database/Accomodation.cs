using System;
using System.Collections.Generic;

#nullable disable

namespace HolidayMakerBackEnd.Models.Database
{
    public partial class Accomodation
    {
        public string Type { get; set; }
        public double Price { get; set; }
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
