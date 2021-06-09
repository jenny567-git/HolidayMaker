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
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotelService;

        public HotelController()
        {
            _hotelService = new HotelService();
        }

        [HttpGet("GetAvailableRooms/{id}")]
        public HotelRoomsViewModel GetAvailableRooms(int id, DateTime date1, DateTime date2)
        {
            var result = _hotelService.GetAvailableRooms(id, date1, date2);

            return result;
        }

        [HttpGet("SavedHotelsInfo")]
        public List<SavedHotelViewModel> GetSavedHotelsInfo(int id)
        {
            var result = _hotelService.GetSavedHotels(id);

            List<SavedHotelViewModel> model = new();

            foreach (var item in result)
            {

                SavedHotelViewModel tmp = new();
                tmp.HotelName = item.Hotel.Name;
                tmp.HotelDescription = item.Hotel.Description;
                tmp.HotelImg = item.Hotel.Img;
                tmp.HotelId = item.HotelId;
                model.Add(tmp);
                // remove for loop after testing, use foreach
            }

            return model;
        }

        [HttpGet("GetReviews/{id}")]
        public IEnumerable<Review> GetReviews(int id)
        {
            var result = _hotelService.GetReviews(id);
            return result;
        }

        [HttpGet("GetById/{id}")]
        public Hotel GetById(int id)
        {
            var result = _hotelService.GetById(id);
            return result;
        }
        
        [HttpGet("GetAllHotels")]
        public IEnumerable<Hotel> GetAllHotels()
        {
            return _hotelService.GetAllHotels();
        }
        
        [HttpGet("GetMaxCap")]
        public int GetMaxCapacityForHotel(int id, DateTime d1, DateTime d2)
        {
            return _hotelService.GetMaxCapacityAvailableForHotel(id, d1, d2);
        }

        [HttpGet("GetHotelsByRandom")]
        public IEnumerable<Hotel> GetHotelsByRandom()
        {
            var result = _hotelService.GetHotelsByRandom();
            return result;
        }
        
        [HttpGet("GetAccomodationFee")]
        public double GetAccomodationFee(int id, string type)
        {
            var result = _hotelService.GetAccomodationFee(id, type);
            return result;
        }

    }
}
