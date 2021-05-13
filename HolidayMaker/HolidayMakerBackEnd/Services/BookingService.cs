using HolidayMakerBackEnd.Models.Database;
using HolidayMakerBackEnd.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Services
{
    public class BookingService
    {

        private readonly HolidayMakerContext _db;
        public BookingService()
        {
            _db = new HolidayMakerContext();
        }


        //public void AddReservation(BookingInputModel model)
        //{
            
        //    var newBooking = new Reservation()
        //    {
        //        StartDate = model.StartDate,
        //        EndDate = model.EndDate,
        //        TotalPrice = model.TotalPrice,
        //        DateCreated = DateTime.Now,
        //        HotelId = model.HotelId,
        //        GuestId = model.GuestId,
                
                             
                
        //    };

            

        //    _db.Reservations.Add(newBooking);
        //    _db.SaveChanges();
        //}

        public void MakeBooking(SearchViewModel model)
        {
            ReservedRoom rr = new ReservedRoom();

            var newBooking = new Reservation()
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                TotalPrice = model.TotalPrice,
                DateCreated = DateTime.Now,
                HotelId = model.HotelId,
                GuestId = model.GuestId,
                FlightId = model.FlightId
                              

            };

            var newReservedRooms = new ReservedRoom()
            {
                RoomId = model.RoomId,
                BookedRooms = model.BookedRooms
            };

            var newResDetails = new ReservationsDetail()
            {
                Adults = model.Adults,
                Children = model.Children,
                ExtraBed = model.ExtraBed,
                CustomerMessage = model.CustomerMessage,
                ReservationId = model.ReservationId,
                Type = model.Type
            };


            AddToReservedRooms(model);
            _db.ReservedRooms.Add(newReservedRooms);
            //_db.ReservationsDetails.Add(newResDetails);
            //_db.Reservations.Add(newBooking);
            _db.SaveChanges();

            
        }

        public void AddToReservedRooms(SearchViewModel model)
        {
            var newReservedRooms = new ReservedRoom()
            {
                RoomId = model.RoomId,
                BookedRooms = model.BookedRooms
            };

            _db.ReservedRooms.Add(newReservedRooms);
            _db.SaveChanges();
        }



      
        public void CalculateCost(int id)
        {
            


        }
       

    }
}



//Räkna ut vad det kommer att kosta i bokningen
