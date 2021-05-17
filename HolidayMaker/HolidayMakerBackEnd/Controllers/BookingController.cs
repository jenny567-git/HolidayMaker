using HolidayMakerBackEnd.Models.Database;
using HolidayMakerBackEnd.Models.ViewModels;
using HolidayMakerBackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly BookingService _bookingService;
        private readonly HolidayMakerContext _db;

        public BookingController()
        {
           _bookingService = new BookingService();
            _db = new HolidayMakerContext();
        }

        [HttpPost("AddBooking")]
        public ActionResult AddBooking(SearchViewModel model)
        {
            _bookingService.MakeBooking(model);
            return Ok();
        }


    }
}
