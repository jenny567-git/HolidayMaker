using HolidayMakerBackEnd.Models.Database;
using HolidayMakerBackEnd.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void AddGuest(GuestInputModel guest)
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
    }
}
