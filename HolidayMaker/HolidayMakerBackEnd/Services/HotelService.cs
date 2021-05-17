using HolidayMakerBackEnd.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HolidayMakerBackEnd.Services
{

    public class HotelRoomsViewModel
    {
        public int SingleRooms { get; set; }
        public int DoubleRooms { get; set; }
        public int FamilyRooms { get; set; }
    }

    public class HotelService
    {
        private readonly HolidayMakerContext _db;

        public HotelService()
        {
            _db = new HolidayMakerContext();
        }

        public HotelRoomsViewModel GetAvailableRooms(int id, DateTime date1, DateTime date2)
        {
            var reservations = _db.Reservations.Where(r => r.HotelId == id && r.StartDate >= date1 && r.EndDate <= date2).Include(r => r.ReservedRooms).ThenInclude(r => r.Room);

            var availableRooms = new Dictionary<string, int>();

            availableRooms.Add("Single", 0);
            availableRooms.Add("Double", 0);
            availableRooms.Add("Family", 0);

            foreach (var reservation in reservations)
            {
                foreach (var reservedRoom in reservation.ReservedRooms)
                {
                    if (reservedRoom.BookedRooms > 0)
                    { // Get amount of bookings for each room type
                        availableRooms[reservedRoom.Room.Type] += reservedRoom.BookedRooms;
                    }
                }
            }

            var roomInfo = _db.Rooms.Where(h => h.HotelId == id).ToList();

            foreach (var key in availableRooms.Keys)
            {
                for (int i = 0; i < roomInfo.Count; i++)
                {
                    if (roomInfo[i].Type == key)
                    { // Get availability of the rooms
                        availableRooms[key] = roomInfo[i].NoOfRooms - availableRooms[key];
                    }
                }
            }
            
            HotelRoomsViewModel vm = new() { SingleRooms = availableRooms["Single"], DoubleRooms = availableRooms["Double"], FamilyRooms = availableRooms["Family"] };

            return vm;
        }

        public IEnumerable<Review> GetReviews(int id)
        {
            return _db.Reviews.Where(r => r.Hotel.Id == id).AsEnumerable();
        }
    }
}
