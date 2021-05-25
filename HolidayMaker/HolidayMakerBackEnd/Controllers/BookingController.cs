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
        private readonly GuestService _guestService;
        private readonly HolidayMakerContext _db;

        public BookingController()
        {
           _bookingService = new BookingService();
            _guestService = new GuestService();
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
            //var reservedRoom = _bookingService.GetReservedRoom(result.Id);
            var reservedRooms = _bookingService.GetReservedRooms(result.Id);
            var test = result.ReservedRooms;
            
            BookingViewModel model = new BookingViewModel();
            model.FullName = result.Guest.FullName;
            model.HotelName = result.Hotel.Name;
            model.HotelId = result.HotelId;
            model.StartDate = result.StartDate;
            model.EndDate = result.EndDate;
            model.DateCreated = result.DateCreated;
            model.TotalPrice = result.TotalPrice;
                       
                model.Adults = 0;
                     model.Adults = res.Adults;
            model.Children = res.Children;
            model.CustomerMessage = res.CustomerMessage;
            model.ReservationId = result.Id;
            model.Type = res.Type;
            model.ExtraBed = res.ExtraBed;
            model.HotelId = result.HotelId;
            //model.ReservedRooms = reservedRooms.ToList();

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
