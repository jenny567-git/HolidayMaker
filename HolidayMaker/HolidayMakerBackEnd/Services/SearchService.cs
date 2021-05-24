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

        //working
        public IEnumerable<AvailableHotelViewModel> GetAvailableHotelsWithStringDates(string input, DateTime startDate, DateTime endDate)
        {
            var hotelsByInput = GetSearchResultByName(input);
            HashSet<AvailableHotelViewModel> hotelList = new HashSet<AvailableHotelViewModel>();

            foreach (var h in hotelsByInput)
            {
                hotelList.Add(new AvailableHotelViewModel((_hs.GetAvailableRooms(h.Id, startDate, endDate)), h));
            }

            return hotelList;
        }

        //working
        public IEnumerable<AvailableHotelViewModel> GetAvailableHotelsWithStringDatesRooms(string input, DateTime startDate, DateTime endDate, int rooms)
        {
            var hotelsByInput = GetSearchResultByName(input);
            HashSet<AvailableHotelViewModel> hotelList = new HashSet<AvailableHotelViewModel>();


            foreach (var h in hotelsByInput)
            {
                var hotelrooms = _hs.GetAvailableRooms(h.Id, startDate, endDate);
                int availableRooms = hotelrooms.SingleRooms + hotelrooms.DoubleRooms + hotelrooms.FamilyRooms;
                //if (hotelrooms.SingleRooms > rooms || hotelrooms.DoubleRooms > rooms || hotelrooms.FamilyRooms > rooms)
                if (availableRooms > rooms)
                {
                    hotelList.Add(new AvailableHotelViewModel(hotelrooms, h));
                }
            }

            return hotelList;
        }

        //working
        public IEnumerable<AvailableHotelViewModel> GetAvailableHotelsWithStringDatesRoomsPeople(string input, DateTime startDate, DateTime endDate, int rooms, int people)
        {
            var hotelsByInput = GetSearchResultByName(input);
            HashSet<AvailableHotelViewModel> hotelList = new HashSet<AvailableHotelViewModel>();

            foreach (var h in hotelsByInput)
            {
                var hotelrooms = _hs.GetAvailableRooms(h.Id, startDate, endDate);
                int availableRooms = hotelrooms.SingleRooms + hotelrooms.DoubleRooms + hotelrooms.FamilyRooms;
                
                if (_hs.GetMaxCapacityAvailableForHotel(h.Id, startDate, endDate) > people)
                {
                    if (availableRooms > rooms)
                    {
                        hotelList.Add(new AvailableHotelViewModel(hotelrooms, h));

                    }
                }
            }

            return hotelList;
        }


        ////not working, exception: There is already an open DataReader associated with this Connection which must be closed 
        //public IEnumerable<AvailableHotelViewModel> GetAvailableHotelsWithDates(DateTime startDate, DateTime endDate)
        //{
        //    var hotels = _hs.GetAllHotels();
        //    HashSet<AvailableHotelViewModel> hotelList = new HashSet<AvailableHotelViewModel>();

        //    foreach (var h in hotels)
        //    {
        //        hotelList.Add(new AvailableHotelViewModel((_hs.GetAvailableRooms(h.Id, startDate, endDate)), h));
        //    }

        //    return hotelList;
        //}
    }
}
