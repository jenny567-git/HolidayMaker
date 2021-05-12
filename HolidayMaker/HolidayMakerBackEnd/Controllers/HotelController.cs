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
        public IEnumerable<ReservedRoom> GetAvailableRooms (int id, DateTime date1, DateTime date2)
        {
            var result = _hotelService.GetAvailableRooms(id, date1, date2);
            return result;
        }

        [HttpGet("GetReviews/{id}")]
        public IEnumerable<Review> GetReviews(int id)
        {
            var result = _hotelService.GetReviews(id);
            return result;
        }

        //[HttpGet("GetRoomsAvailableByDate")]
        //public IEnumerable<Room> GetRoomsAvailableByDate(DateTime date)
        //{
        //    var result = _hotelService.GetRoomsAvailableByDate(date);
        //    return result;
        //}

       
    }
}
