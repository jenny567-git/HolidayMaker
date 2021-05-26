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

        [HttpGet("Booking/{id}")]
        public ActionResult<ReservationViewModel> GetBookingById(int id)
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

                return StatusCode(204);
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
                if (item.Room.Type=="Single")
                {
                    model.hotelRoomsViewModel.SingleRooms = item.BookedRooms;
                }
                else if (item.Room.Type =="Double")
                {
                    model.hotelRoomsViewModel.DoubleRooms = item.BookedRooms;
                }else if (item.Room.Type == "Family")
                {
                    model.hotelRoomsViewModel.FamilyRooms =item.BookedRooms;
                }
                
            }
            

            return model;
           

        }

        //[HttpGet("Bookings/{id}")]
        //public GuestAllBookingsViewModel GetAllBookingByGuestId(int id)
        //{
        //    GuestAllBookingsViewModel model = new GuestAllBookingsViewModel();
        //    //hämta en gäst
        //    //hämta ut gästens alla bokningar
        //    //hämta ut tillhörande detaljer
        //    //hämta ut tillhörande bokade rum

        //    var guest = _guestService.FindGuestById(id);
        //    var result = _bookingService.GetAllBookingByGuestId(guest.Id);
        //    var nummer = new List<int>();
        //    foreach (var item in result)
        //    {
        //        nummer.Add(item.Id);
        //    }
        //    var reservationsDetails = _bookingService.GetAllReservationsDetails(nummer);
        //    return model;



        //}
    }
}
