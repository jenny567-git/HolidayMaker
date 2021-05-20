using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerBackEnd.Models.Database;
using HolidayMakerBackEnd.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HolidayMakerBackEnd.Services
{
    public class SearchService
    {
        private readonly HolidayMakerContext _db;
        private readonly HotelService _hs;

        public SearchService()
        {
            _db = new HolidayMakerContext();
            _hs = new HotelService();
        }

        //search by string, dates, rooms
        //search by string + filter(s)

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

        //includes hotel name, city name and country name
        public IEnumerable<Hotel> GetSearchResultByName(string input)
        {
            var result = GetHotelByCity(input).ToList();
            var hotelCountry = GetHotelByCountry(input);
            foreach(var h in hotelCountry)
            {
                if (!result.Contains(h)) {
                    result.Add(h);
                }
            }

            var hotelName = GetHotelByName(input);
            foreach (var item in hotelName)
            {
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
            }
            
            return result.AsEnumerable();
        }

        //public IEnumerable<Hotel> GetAvailableHotels(string input, DateTime startDate, DateTime endDate)
        //{
        //    var hotelsByInput = GetSearchResultByName(input);
        //    List<Reservation> bookedHotel = new List<Reservation>();
        //    foreach (var h in hotelsByInput)
        //    {
        //        bookedHotel.Add(_db.Reservations.Where(r => r.HotelId == h.Id).ToList());
        //    }
        //}
    }
}
