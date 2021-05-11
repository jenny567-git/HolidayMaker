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
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotelService;

        public HotelController()
        {
            _hotelService = new HotelService();
        }

        [HttpGet("GetAvailableRooms/{id}")]
        public IEnumerable<Room> GetAvailableRooms (int id)
        {
            var result = _hotelService.GetAvailableRooms(id);
            return result;
        }

        [HttpGet("GetReviews/{id}")]
        public IEnumerable<Review> GetReviews(int id)
        {
            var result = _hotelService.GetReviews(id);
            return result;
        }

        [HttpGet("GetRoomsAvailableByDate")]
        public IEnumerable<Room> GetRoomsAvailableByDate(DateTime date)
        {
            var result = _hotelService.GetRoomsAvailableByDate(date);
            return result;
        }


    }
}
