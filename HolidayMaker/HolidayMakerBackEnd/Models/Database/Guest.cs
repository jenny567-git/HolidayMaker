using System;
using System.Collections.Generic;

#nullable disable

namespace HolidayMakerBackEnd.Models.Database
{
    public partial class Guest
    {
        public Guest()
        {
            Reservations = new HashSet<Reservation>();
            Reviews = new HashSet<Review>();
            SavedHotels = new HashSet<SavedHotel>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<SavedHotel> SavedHotels { get; set; }
    }
}
