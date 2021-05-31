using HolidayMakerBackEnd.Models.Database;
using HolidayMakerBackEnd.Models.ViewModels;
using HolidayMakerBackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly HolidayMakerContext _db = new HolidayMakerContext();
        private readonly GuestService _guestService;

        public GuestController()
        {
            _guestService = new GuestService();

        }

        [HttpGet("GetGuestById/{id}")]
        public IEnumerable<Guest> GetGuestById(int id)
        {
            
            var result = _guestService.GetGuestById(id);
            return result;
        }

        [HttpGet("GetSavedHotels/{id}")]
        public IEnumerable<SavedHotel> GetSavedHotels(int id)
        {
            var result = _guestService.GetSavedHotels(id);
            return result;
        }
        [HttpPost("addGuest")]
        public async Task<Guest> AddGuest(AddGuestViewModel guest)
        {
            var newGuest = new Guest()
            {
                FullName = guest.FullName,
                Street = guest.Street,
                ZipCode = guest.ZipCode,
                City = guest.City,
                Country = guest.Country,
                Phone = guest.Phone,
                Email = guest.Email

            };

            _db.Guests.Add(newGuest);
            await _db.SaveChangesAsync();
            return newGuest;
        }

        [HttpPost("AddReview")]
        public ActionResult AddReview([FromBody]ReviewModel model)
        {
            _guestService.AddReview(model);
                return Ok();
        }
        [HttpPost("saveFavoriteHotel")]
        public ActionResult SaveHotelToFavorites(SaveModel model)
        {
            _guestService.SaveHotel(model);
            return Ok();
        }
        //[HttpGet("getAllReservationForGuest/{id}")]
        //public BookingViewModel GetGuestReservation(int id)
        //{
        //    var result = _guestService.GetGuestReservation(id);
        //    return result;
        //}
       

        

    }
}
