using HolidayMakerBackEnd.Models.Database;
using HolidayMakerBackEnd.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using HolidayMakerBackEnd.Services;

namespace HolidayMakerBackEnd.Services
{
    public class GuestService
    {

        private readonly HolidayMakerContext _db;

        public GuestService()
        {
            _db = new HolidayMakerContext();
        }


        public IEnumerable<SavedHotel> GetSavedHotels(int id)
        {
            return _db.SavedHotels.Where(n => n.GuestId == id).AsEnumerable();
        }

        public IEnumerable<Guest> GetGuestById(int id)
        {
            return _db.Guests.Where(g => g.Id == id);
        }

        public void AddGuest(AddGuestViewModel guest)
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
            _db.SaveChanges();
        }

        public async Task<int> EditGuest(Guest guest)
        {
            _db.Guests.Update(guest);
            return await _db.SaveChangesAsync();
        }

        public void RemoveGuest(int id)
        {
            var guest = _db.Guests.SingleOrDefault(g => g.Id == id);
            _db.Guests.Remove(guest);
            _db.SaveChanges();

        }

        public void AddReview(ReviewModel model)
        {
            var newReview = new Review()
            {
                Rating = model.Rating,
                Description = model.Description,
                HotelId = model.HotelID,
                GuestId = model.GuestID


            };
            _db.Reviews.Add(newReview);
            _db.SaveChanges();
        }

        public void SaveHotel(SaveModel model)
        {
            var newSaveHotel = new SavedHotel()
            {
                HotelId = model.HotelID,
                GuestId = model.GuestID,
            };

            _db.SavedHotels.Add(newSaveHotel);
            _db.SaveChanges();
        }

        public Guest FindGuestById(int id)
        {
            return _db.Guests.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Reservation> GetReservationsByID(int id)
        {
            var result = _db.Reservations.Include(r => r.Guest).Include(h => h.Hotel).Where(r => r.Id == id).AsEnumerable();

            var test = _db.Reservations.Where(r => r.GuestId == id).Include(r => r.Hotel).ThenInclude(r => r.Rooms).AsEnumerable();

            return test;
        }

        public LoginResponseViewModel Login(LoginRequestViewModel model)
        {
            Guest user =null;
            if (model.UserId !=0)
            {
                user = _db.Guests.FirstOrDefault(x => x.Id == model.UserId);
               
            }
            else
            {
                user = _db.Guests.FirstOrDefault(x => x.Email == model.Email);
                bool isValid = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);

                
            }

            if (user == null)
            {
                return null;
            }

            return new LoginResponseViewModel(user);


        }



    }

    
    public class InputData
    {
        public int Id { get; set; }
    }   
}

