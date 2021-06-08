using System;
using System.Collections.Generic;

#nullable disable

namespace HolidayMakerBackEnd.Models.Database
{
    public partial class Room
    {
        public Room()
        {
            ReservedRooms = new HashSet<ReservedRoom>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int MaxCapacity { get; set; }
        public int HotelId { get; set; }
        public int NoOfRooms { get; set; }
        public string Img { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<ReservedRoom> ReservedRooms { get; set; }
    }
}
