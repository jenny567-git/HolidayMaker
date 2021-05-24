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

        [HttpGet("Booking/{id}")]
        public BookingViewModel GetBookingById(int id)
        {
            var result = _bookingService.GetBookingById(id);
            var res = _bookingService.GetReservationsDetail(result.Id);
            var reservedRoom = _bookingService.GetReservedRoom(result.Id);
            var reservedRooms = _bookingService.GetReservedRooms(result.Id);
            var test = result.ReservedRooms;
            
            BookingViewModel model = new BookingViewModel();
            model.FullName = result.Guest.FullName;
            model.HotelId = result.HotelId;
            model.StartDate = result.StartDate;
            model.EndDate = result.EndDate;
            model.DateCreated = result.DateCreated;
            model.TotalPrice = result.TotalPrice;

            model.Adults = res.Adults;
            model.Children = res.Children;
            model.CustomerMessage = res.CustomerMessage;
            model.ReservationId = result.Id;
            model.Type = res.Type;
            model.ExtraBed = res.ExtraBed;
            model.HotelId = result.HotelId;
            model.ReservedRooms = reservedRooms.ToList();


            return model;

        }

        [HttpGet("Bookings/{id}")]
        public IEnumerable<Reservation> GetAllBookingByGuestId(int id)
        {
            var result = _bookingService.GetAllBookingByGuestId(id);
            return result;
        }
    }
}
