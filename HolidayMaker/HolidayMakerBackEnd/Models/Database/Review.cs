using System;
using System.Collections.Generic;

#nullable disable

namespace HolidayMakerBackEnd.Models.Database
{
    public partial class Review
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public int HotelId { get; set; }
        public int GuestId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Guest IdNavigation { get; set; }
    }
}
