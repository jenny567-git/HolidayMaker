using HolidayMakerBackEnd.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HolidayMakerBackEnd.Services
{

    public class HotelService
    {
        private readonly HolidayMakerContext _db;
        //public bool availableSingle { get; set; }
        //public bool availableDouble { get; set; }
        //public bool availableFamily { get; set; }

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

            //new added
            //availableSingle = (availableRooms["Single"] > 0) ? true : false;
            //availableDouble = (availableRooms["Double"] > 0) ? true : false;
            //availableFamily = (availableRooms["Family"] > 0) ? true : false;

            return vm;
        }

        public IEnumerable<Review> GetReviews(int id)
        {
            return _db.Reviews.Where(r => r.Hotel.Id == id).AsEnumerable();
        }

        public Hotel GetById(int id)
        {
            return _db.Hotels.SingleOrDefault(h => h.Id == id);
        }


        public IEnumerable<Hotel> GetHotelsByRandom()
        {
            Random rand = new Random();
            int num1 = rand.Next(0, 5);
            int num2 = rand.Next(0, 5);
            int num3 = rand.Next(0, 5);

            return _db.Hotels.Where(x => x.Id == num1);
        }
    }
}
