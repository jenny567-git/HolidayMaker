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

        public HotelService()
        {
            _db = new HolidayMakerContext();
        }

        public IEnumerable<Hotel> GetAvailableRooms(int id, DateTime date1, DateTime date2)
        {
            
            



            //var test = _db.Hotels.Where(r => r.Id == id).Select(r => r.Rooms).AsEnumerable();
            //return test;


            //funkar
            //var reservations = _db.Reservations.Include(r => r.ReservedRooms).Where(r => r.HotelId == id && r.StartDate <= date1 && r.EndDate >= date2);
            //return null;

            //using (HolidayMakerContext db = new HolidayMakerContext())
            //{
            //    List<Hotel> hotels = db.Hotels.ToList();
            //    List<Room> rooms = db.Rooms.ToList();
            //    List<ReservedRoom> reservedRooms = db.ReservedRooms.ToList();

            //    var totalmess = from h in hotels
            //                    join r in rooms on i.Room_Id equals
            //                    from r in table1.ToList()

            //}


            //addera ihop bokninagar, kolla hur många rumstyp
            //



            //var rooms = _db.Rooms.Where(r => r.Hotel.Id == id).AsEnumerable();
            //var availableRooms = rooms.Where(r => r.)
        }

        public IEnumerable<Review> GetReviews(int id)
        {
            return _db.Reviews.Where(r => r.Hotel.Id == id).AsEnumerable();
        }

        //public IEnumerable<Room> GetRoomsAvailableByDate(DateTime date)
        //{
            
        //}

    }
}
