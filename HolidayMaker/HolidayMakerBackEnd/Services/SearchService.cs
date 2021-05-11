using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerBackEnd.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace HolidayMakerBackEnd.Services
{
    public class SearchService
    {
        private readonly HolidayMakerContext _db;

        public SearchService()
        {
            _db = new HolidayMakerContext();
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _db.Hotels.AsEnumerable();

        }

        public IEnumerable<Hotel> GetHotelByName(string input)
        {
            return _db.Hotels.Where(n => n.Name.Contains(input)).AsEnumerable();
        }

        public IEnumerable<Hotel> GetHotelByCity(string input)
        {

            var result = _db.Hotels.Where(n => n.City.CityName == input).AsEnumerable();

            return result;

        }

        public IEnumerable<Hotel> GetHotelByCountry(string input)
        {

            var result = _db.Hotels.Where(n => n.Country.CountryName == input).AsEnumerable();

            return result;
           
        }

        

    }
}
