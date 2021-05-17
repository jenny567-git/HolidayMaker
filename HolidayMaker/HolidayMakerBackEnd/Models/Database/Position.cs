using System;
using System.Collections.Generic;

#nullable disable

namespace HolidayMakerBackEnd.Models.Database
{
    public partial class Position
    {
        public string X { get; set; }
        public string Y { get; set; }
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
