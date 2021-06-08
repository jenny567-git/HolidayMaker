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
        public async Task<Guest> AddGuest(AddGuestViewModel model)
        {
            var newGuest = new Guest()
            {
                FullName = model.FullName,
                Street = model.Street,
                ZipCode = model.ZipCode,
                City = model.ZipCode,
                Country = model.Country,
                Phone = model.Phone,
                Email = model.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
                
                

            };

            _db.Guests.Add(newGuest);
            await _db.SaveChangesAsync();

            return newGuest;
        }

        [HttpPost("AddReview")]
        public ActionResult AddReview([FromBody]ReviewModel model)
        {
            int result = _guestService.AddReview(model);
                return Ok(result);
        }

        [HttpPost("saveFavoriteHotel")]
        public ActionResult SaveHotelToFavorites(SaveModel model)
        {
            int result = _guestService.SaveHotel(model);
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequestViewModel model)
        {
            
            var response = _guestService.Login(model);
            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(response);

                


        }



        [HttpDelete("removeFavoriteHotel")]
        public ActionResult RemoveHotelFromFavorites(SaveModel model)
        {
            int result = _guestService.RemoveSavedHotel(model);
            return Ok(result);
        }

        [HttpPost("updateGuest")]
        public void UpdateGuest(UpdateGuestViewModel model)
        {
            var guest = _db.Guests.FirstOrDefault(x => x.Id == model.Id);
            guest.FullName = model.FullName;
            guest.Email = model.Email;
            guest.Phone = model.Phone;
            guest.Street = model.Street;
            guest.ZipCode = model.ZipCode;
            guest.City = model.City;
            guest.Country = model.Country;
            guest.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            _db.SaveChanges();
        }
    }
}
