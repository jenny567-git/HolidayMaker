using System;
using System.Collections.Generic;

#nullable disable

namespace HolidayMakerBackEnd.Models.Database
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
