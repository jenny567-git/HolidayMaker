using HolidayMakerBackEnd.Models.Database;
using HolidayMakerBackEnd.Models.ViewModels;
using HolidayMakerBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace HolidayMakerBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly BookingService _bookingService;
        private readonly GuestService _guestService;

        public BookingController()
        {
           _bookingService = new BookingService();
            _guestService = new GuestService();
        }

        [HttpPost("AddBooking")]
        public ActionResult AddBooking(SearchViewModel model)
        {
            _bookingService.MakeBooking(model);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<ReservationViewModel> Get(int BookingId)
        {
            ReservationViewModel model = new();
            int statusCode = this.GetBookingById(BookingId, ref model);

            if (statusCode == 200)
            {
                return Ok(model);
            }
            return Ok();
        }


        private int GetBookingById(int id, ref ReservationViewModel reference)
        {
            var result = new Reservation();
            var reservationDetails = new ReservationsDetail();
            IEnumerable<ReservedRoom> reservedRooms;
            try
            {
                result = _bookingService.GetBookingById(id);
                reservationDetails = _bookingService.GetReservationsDetail(result.Id);
                reservedRooms = _bookingService.GetReservedRooms(result.Id);
            }
            catch (Exception e)
            {

                return 204;
            }


            ReservationViewModel model = new ReservationViewModel();
            model.FullName = result.Guest.FullName;
            model.HotelName = result.Hotel.Name;
            model.HotelId = result.HotelId;
            model.StartDate = result.StartDate;
            model.EndDate = result.EndDate;
            model.DateCreated = result.DateCreated;
            model.TotalPrice = result.TotalPrice;
            model.Adults = reservationDetails.Adults;
            model.Children = reservationDetails.Children;
            model.CustomerMessage = reservationDetails.CustomerMessage;
            model.ReservationId = result.Id;
            model.Type = reservationDetails.Type;
            model.ExtraBed = reservationDetails.ExtraBed;
            model.HotelId = result.HotelId;

            foreach (var item in reservedRooms)
            {
                model.NumberOfRooms += item.BookedRooms;
                if (item.Room.Type == "Single")
                {
                    model.hotelRoomsViewModel.SingleRooms = item.BookedRooms;
                }
                else if (item.Room.Type == "Double")
                {
                    model.hotelRoomsViewModel.DoubleRooms = item.BookedRooms;
                }
                else if (item.Room.Type == "Family")
                {
                    model.hotelRoomsViewModel.FamilyRooms = item.BookedRooms;
                }

            }

            reference = model;
            return 200;
        }

        [HttpGet("guest/{id}")]
        public List<ReservationViewModel> GetAllBookingByGuestId(int id)
        {
            GuestAllBookingsViewModel model = new GuestAllBookingsViewModel();
            //hämta en gäst
            //hämta ut gästens alla bokningar
            //hämta ut tillhörande detaljer
            //hämta ut tillhörande bokade rum

            var guest = _guestService.FindGuestById(id);
            var bookingIds = _bookingService.GetAllBookingByGuestId(guest.Id);

            List<ReservationViewModel> bookings = new();

            foreach (var booking in bookingIds)
            {
                ReservationViewModel tmp = new();
                GetBookingById(booking.Id, ref tmp);
                bookings.Add(tmp);
            }

            return bookings;
        }
    }
}
