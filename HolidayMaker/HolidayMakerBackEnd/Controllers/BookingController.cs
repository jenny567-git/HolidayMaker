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
        private readonly HotelService _hotelService;

        public BookingController()
        {
           _bookingService = new BookingService();
            _guestService = new GuestService();
            _hotelService = new HotelService();
        }

        [HttpPost("AddBooking")]
        public ActionResult AddBooking(SearchViewModel model)
        {
            int bookingId = _bookingService.MakeBooking(model);
            return Ok(bookingId);
        }

        [HttpPut("CancelBooking")]
        public ActionResult CancelBooking(int id)
        {
            int result = _bookingService.CancelBooking(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<ReservationViewModel> Get(int id)
        {
            ReservationViewModel model = new();
            int statusCode = this.GetBookingById(id, ref model);

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
            catch (Exception)
            {

                return 204;
            }


            ReservationViewModel model = new ReservationViewModel();
            model.FullName = result.FullName;
            if (result.FullName != null)
            {
                model.GuestDetails.FirstName = result.FullName.Split(' ')[0];
                model.GuestDetails.LastName = result.FullName.Split(' ')[1];
            }
            model.GuestDetails.Email = result.Email;
            model.GuestDetails.Street = result.Street;
            model.GuestDetails.PhoneNumber = result.Phone;
            model.GuestDetails.City = result.City;
            model.GuestDetails.ZipCode = result.Zipcode;
            model.GuestDetails.Message = reservationDetails.CustomerMessage;
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
            model.Status = result.Status;
            var getHotelImg = _hotelService.GetById(result.HotelId);
            model.HotelImg = getHotelImg.Img;

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

        [HttpPut("{id}")]
        public int UpdateBookingDetails(int id, CustomerDetailsModel model)
        {
            try
            {
                _bookingService.UpdateReservation(model, id);
            }
            catch (Exception)
            {
                return 1; // failed
            }
            return 0;
        }
    }
}
