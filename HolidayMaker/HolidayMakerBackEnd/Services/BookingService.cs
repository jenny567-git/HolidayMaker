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


        public void AddReservation(BookingInputModel model)
        {
            var newBooking = new Reservation()
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                //TotalPrice = CalculateCost(),
                DateCreated = DateTime.Now,
                HotelId = model.HotelId,
                GuestId = model.GuestId,
               
                
            };

            _db.Reservations.Add(newBooking);
            _db.SaveChanges();
        }
      
        public void CalculateCost()
        {

        }
       

    }
}



//Räkna ut vad det kommer att kosta i bokningen
