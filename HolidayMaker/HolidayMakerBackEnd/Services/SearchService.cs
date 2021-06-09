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

        public IEnumerable<Hotel> GetHotelByName(string input)
        {
            return _db.Hotels.Where(n => n.Name.Contains(input)).Include(n => n.Country).Include(n => n.City).Include(r => r.Rooms).AsEnumerable();
        }

        public IEnumerable<Hotel> GetHotelByCity(string input)
        {

            var result = _db.Hotels.Where(n => n.City.CityName.Contains(input)).Include(n => n.Country).Include(n => n.City).Include(r => r.Rooms).AsEnumerable();

            return result;

        }

        public IEnumerable<Hotel> GetHotelByCountry(string input)
        {

            var result = _db.Hotels.Where(n => n.Country.CountryName.Contains(input)).Include(n => n.Country).Include(n=> n.City).Include(r => r.Rooms).AsEnumerable();

            return result;

        }

        //includes hotel name, city name and country name
        public IEnumerable<Hotel> GetAllHotelByInput(string input)
        {
            var result = GetHotelByCity(input).ToHashSet();
            var hotelCountry = GetHotelByCountry(input);

            foreach (var h in hotelCountry)
            {
                result.Add(h);
            }

            var hotelName = GetHotelByName(input);
            foreach (var item in hotelName)
            {
                result.Add(item);
            }

            return result.AsEnumerable();
        }


        //working: searchstring + dates + rooms + people
        public IEnumerable<AvailableHotelViewModel> GetAvailableHotels(DateTime startDate, DateTime endDate, int rooms, int people, string input = null)
        {
            IEnumerable<Hotel> hotels;
            if (input == null || input == "")
            {
                hotels = _hs.GetAllHotels();
            }
            else
            {
                hotels = GetAllHotelByInput(input);
            }

            HashSet<AvailableHotelViewModel> hotelList = new HashSet<AvailableHotelViewModel>();
            SearchAvailableRoomsDependingOnPeople(startDate, endDate, rooms, people, hotels, hotelList);

            return hotelList;
        }

        public IEnumerable<string> GetSearchAutoComplete()
        {
            List<string> list = new List<string>();

            var countries = _db.Countries;
            foreach (var country in countries)
            {
                list.Add(country.CountryName);
            }

            var cities = _db.Cities;
            foreach (var city in cities)
            {
                list.Add(city.CityName);
            }

            var hotels = _db.Hotels;
            foreach (var hotel in hotels)   
            {
                list.Add(hotel.Name);
            }

            return list.AsEnumerable();
        }

        //method to get available rooms and checks if hotel has capacity for selected people
        private void SearchAvailableRoomsDependingOnPeople(DateTime startDate, DateTime endDate, int rooms, int people, IEnumerable<Hotel> hotelsByInput, HashSet<AvailableHotelViewModel> hotelList)
        {
            foreach (var h in hotelsByInput)
            {
                var hotelrooms = _hs.GetAvailableRooms(h.Id, startDate, endDate);
                int availableRooms = hotelrooms.SingleRooms + hotelrooms.DoubleRooms + hotelrooms.FamilyRooms;

                if (_hs.GetMaxCapacityAvailableForHotel(h.Id, startDate, endDate) >= people)
                {
                    if (availableRooms >= rooms)
                    {
                        hotelList.Add(new AvailableHotelViewModel(hotelrooms, h));

                    }
                }
            }
        }
    }
}
