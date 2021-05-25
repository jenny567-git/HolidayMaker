using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerBackEnd.Services;
using HolidayMakerBackEnd.Models.Database;
using HolidayMakerBackEnd.Models.ViewModels;

namespace HolidayMakerBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {//test
        private readonly SearchService _searchService;

        public SearchController()
        {
            _searchService = new SearchService();
        }

        [HttpGet("GetAllHotels")]
        public IEnumerable<Hotel> GetAllHotel()
        {
            
                var result = _searchService.GetAllHotels();
                return result;

        }

        [HttpGet("GetHotelByName")]
        public IEnumerable<Hotel> GetHotelByName(string input)
        {
            try
            {
                var result = _searchService.GetHotelByName(input);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ArgumentException("Named Hotel not found");
            }

            //var result = _searchService.GetHotelByName(input);
            //return result;
        }

        [HttpGet("GetHotelByCity")]
        public IEnumerable<Hotel> GetHotelByCity(string input)
        {
             
            var result = _searchService.GetHotelByCity(input);
            return result;
          
        }

        [HttpGet("GetHotelByCountry")]
        public IEnumerable<Hotel> GetHotelByCountry(string input)
        {
            var result = _searchService.GetHotelByCountry(input);
            return result;
        }



        [HttpGet("GetSearchResultByName")]
        public IEnumerable<Hotel> GetSearchResultByName(string input)
        {
            var result = _searchService.GetSearchResultByName(input);
            return result;
        }
        
        [HttpGet("searchstring")]
        public IEnumerable<AvailableHotelViewModel> GetAvailableHotelsWithStringDates(string input, DateTime startDate, DateTime endDate)
        {
            var result = _searchService.GetAvailableHotelsWithStringDates(input, startDate, endDate);
            return result;
        }
        
        [HttpGet("search")]
        public IEnumerable<AvailableHotelViewModel> GetAvailableHotelsWithStringDatesRooms(string input, DateTime startDate, DateTime endDate, int rooms)
        {
            var result = _searchService.GetAvailableHotelsWithStringDatesRooms(input, startDate, endDate, rooms);
            return result;
        }
        
        [HttpGet("searchdates")]
        public IEnumerable<AvailableHotelViewModel> GetAvailableHotelsWithDates(DateTime startDate, DateTime endDate)
        {
            var result = _searchService.GetAvailableHotelsWithDates(startDate, endDate);
            return result;
        }
        
        [HttpGet("searchpeople")]
        public IEnumerable<AvailableHotelViewModel> GetAvailableHotelsWithStringDatesRoomsPeople(string input, DateTime startDate, DateTime endDate, int rooms, int people)
        {
            var result = _searchService.GetAvailableHotelsWithStringDatesRoomsPeople(input, startDate, endDate, rooms, people);
            return result;
        }
        
        [HttpGet("searchWithNoString")]
        public IEnumerable<AvailableHotelViewModel> GetAvailableHotelsWithDatesPeopleRooms(DateTime startDate, DateTime endDate, int rooms, int people)
        {
            var result = _searchService.GetAvailableHotelsWithDatesPeopleRooms(startDate, endDate, rooms, people);
            return result;
        }



    }
}
