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
        private readonly HotelService _hotelService;

        public SearchController()
        {
            _searchService = new SearchService();
        }

        [HttpGet("GetAllHotels")]
        public IEnumerable<Hotel> GetAllHotel()
        {
                var result = _hotelService.GetAllHotels();
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

        }

        [HttpGet("GetHotelByCity")]
        public IEnumerable<AvailableHotelViewModel> GetHotelByCity(string input)
        {
            IEnumerable<Hotel> searchresult = _searchService.GetHotelByCity(input);

            List<AvailableHotelViewModel> viewModelList = new List<AvailableHotelViewModel>();

            foreach (var hotel in searchresult)
            {
                viewModelList.Add(new AvailableHotelViewModel { Hotel = hotel });
            }
            
            var result = viewModelList.AsEnumerable();

            return result;
          
        }

        [HttpGet("GetHotelByCountry")]
        public IEnumerable<Hotel> GetHotelByCountry(string input)
        {
            var result = _searchService.GetHotelByCountry(input);
            return result;
        }



        [HttpGet("GetAllHotelByInput")]
        public IEnumerable<Hotel> GetAllHotelByInput(string input)
        {
            var result = _searchService.GetAllHotelByInput(input);
            return result;
        }
        
        [HttpGet("search")]
        public IEnumerable<AvailableHotelViewModel> GetAvailableHotelsWithStringDatesRoomsPeople(DateTime? startDate=null, DateTime? endDate=null, int? rooms=null, int? people=null, string input = null)
        {
            IEnumerable<AvailableHotelViewModel> result = null;
            

            if (rooms.HasValue && people.HasValue && (input == null || input == ""))
            {
                //all fields except string has value
                result = _searchService.GetAvailableHotels(startDate.Value, endDate.Value, rooms.Value, people.Value);
            }else if(startDate == null && endDate == null)
            {
                //only string input
                IEnumerable<Hotel> searchresult = _searchService.GetAllHotelByInput(input);
                
                List<AvailableHotelViewModel> viewModelList = new List<AvailableHotelViewModel>();

                foreach (var hotel in searchresult)
                {
                    viewModelList.Add(new AvailableHotelViewModel { Hotel = hotel});    
                }
                result = viewModelList.AsEnumerable();
            } else
            {
                //all fields has value
                result = _searchService.GetAvailableHotels(startDate.Value, endDate.Value, rooms.Value, people.Value, input);
            }
            
            return result;
        }

        [HttpGet("GetSearchAutoComplete")]
        public IEnumerable<string> GetSearchAutoComplete()
        {
            return _searchService.GetSearchAutoComplete();
        }

    }
}
