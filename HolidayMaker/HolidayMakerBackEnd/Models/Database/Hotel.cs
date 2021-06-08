using System;
using System.Collections.Generic;

#nullable disable

namespace HolidayMakerBackEnd.Models.Database
{
    public partial class Hotel
    {
        public Hotel()
        {
            Accomodations = new HashSet<Accomodation>();
            Reservations = new HashSet<Reservation>();
            Reviews = new HashSet<Review>();
            Rooms = new HashSet<Room>();
            SavedHotels = new HashSet<SavedHotel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public string Description { get; set; }
        public bool Pool { get; set; }
        public bool NightEntertainment { get; set; }
        public bool ChildClub { get; set; }
        public bool Restaurant { get; set; }
        public double BeachDistance { get; set; }
        public double CentrumDistance { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int? ExtraBedFee { get; set; }
        public string Img { get; set; }

        public virtual ICollection<Accomodation> Accomodations { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<SavedHotel> SavedHotels { get; set; }
    }
}
