using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerBackEnd.Services;
using HolidayMakerBackEnd.Models.Database;

namespace HolidayMakerBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
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
                throw new ArgumentException("named Hotel not found");
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
    }
}
