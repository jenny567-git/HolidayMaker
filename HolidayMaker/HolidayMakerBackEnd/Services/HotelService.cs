using HolidayMakerBackEnd.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Services
{
    public class HotelService
    {
        private readonly HolidayMakerContext _db;

        public HotelService()
        {
            _db = new HolidayMakerContext();
        }

        public IEnumerable<Room> GetAvailableRooms(int id)
        {
            return _db.Rooms.Where(r => r.Hotel.Id == id).AsEnumerable();
        }

        public IEnumerable<Review> GetReviews(int id)
        {
            return _db.Reviews.Where(r => r.Hotel.Id == id).AsEnumerable();
        }

        public IEnumerable<Room> GetRoomsAvailableByDate(DateTime date)
        {
            return _db.ReservedRooms.Where(r => r.Reservation.StartDate == date).AsEnumerable();
        }

    }
}
