using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace HolidayMakerBackEnd.Models.Database
{
    public partial class City
    {
        public City()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        [JsonIgnore]
        public virtual Country Country { get; set; }
        [JsonIgnore]
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
