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

        //public IEnumerable<Hotel> GetAvailableRooms(int id, DateTime date1, DateTime date2)
        //{
        //    //var summa = _db.ReservedRooms.Where(x => x.RoomId == id);
        //    //var a = _db.ReservedRooms.Sum(x => x.RoomId);
        //    //return summa;

        //    //var result = _db.Rooms.Where(x => x.HotelId == id).AsEnumerable();
        //    //return result;

        //    //var test = _db.Hotels.Where(r => r.Id == id).Select(r => r.Rooms).AsEnumerable();
        //    //return test;

        //    //funkar
        //    //var reservationsForASpecHotel = _db.Reservations.Include(r => r.ReservedRooms).Where(r => r.HotelId == id && r.StartDate <= date1 && r.EndDate >= date2);
        //    var reservedRoomsIDs = reservationsForASpecHotel.Where(r => r.ReservedRooms
        //return null;

        //    // var aQuery = (from h in _db.Hotel
        //    //                 join r in _db.Reservation
        //    //                 on r.ReservationId equals h.HotelId
        //    //                 join rr in ReservedRooms 


        //    //using (var context = new Reservation)
        //    //{
        //    //    var reservation = _db.ReservedRooms
        //    //          .join(
        //    //          _db.Rooms,
        //    //          Rooms => rooms.RoomsId,
        //    //          
        //    //          )
        //    //}


        //    //addera ihop bokninagar, kolla hur många rumstyp
        //    //



        //    //var rooms = _db.Rooms.Where(r => r.Hotel.Id == id).AsEnumerable();
        //    //var availableRooms = rooms.Where(r => r.)
        //}

        public IEnumerable<Review> GetReviews(int id)
        {
            return _db.Reviews.Where(r => r.Hotel.Id == id).AsEnumerable();
        }

       
        public object FindHotelAndAvailableRooms(int id)
        {

            


            var result = (from hotel in _db.Hotels
                          join room in _db.Rooms on hotel.Id equals room.HotelId
                          
                          where hotel.Id == room.HotelId
                          where hotel.Id == id
                          select new
                          {
                              Name = hotel.Name,
                              NoOfRooms = room.NoOfRooms,
                              RoomType = room.Type


                          }


                          ).ToList();
            return result;
        }



    }
}
