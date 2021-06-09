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

        [HttpPost("removeGuest")]
        public void RemoveGuest(Test id)
        {
           _guestService.RemoveGuest(id.Id);
        }

        [HttpPost("updateGuest")]
        public void UpdateGuest(UpdateGuestViewModel model)
        {

            if (model.Id != 0)
            {

                var guest = _db.Guests.FirstOrDefault(x => x.Id == model.Id);
                if (model.FullName != "")
                {
                    guest.FullName = model.FullName;
                }

                if (model.Email != "")
                {
                    guest.Email = model.Email;
                }

                if (model.Phone != "")
                {
                    guest.Phone = model.Phone;
                }

                if (model.Street != "")
                {
                    guest.Street = model.Street;

                }

                if (model.ZipCode != "")
                {
                    guest.ZipCode = model.ZipCode;
                }

                if (model.City != "")
                {
                    guest.City = model.City;
                }

                if (model.Country != "")
                {
                    guest.Country = model.Country;
                }

                if (model.Password != "")
                {
                    guest.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                }


            }

            _db.SaveChanges();
        }

    }

    public class Test
    {
        public int Id { get; set; }
    }
}
