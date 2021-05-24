using HolidayMakerBackEnd.Models.Database;
using HolidayMakerBackEnd.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
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


        public int latestId;
        public string latestType;


        //removeBooking missing




        public Reservation GetBookingById(int id)
        {
            var result = _db.Reservations.Include(r => r.Guest).Include(h => h.Hotel).Include(r => r.ReservedRooms).SingleOrDefault(r => r.Id == id);
            return result;
        }

        public IEnumerable<Reservation> GetAllBookingByGuestId(int id)
        {
            var result = _db.Reservations.Where(b => b.GuestId == id);
            return result;
        }

        public void MakeBooking(SearchViewModel model)
        {

            var newReservation = new Reservation()
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                DateCreated = DateTime.Now,
                HotelId = model.HotelId,
                GuestId = model.GuestId,
                
            };

            _db.Reservations.Add(newReservation);
            _db.SaveChanges();
            latestId = newReservation.Id;

            var Acc = new Accomodation();
           

            latestType = Acc.Type = model.Type;
            


            
            var newResDetails = new ReservationsDetail()
            {
                Adults = model.Adults,
                Children = model.Children,
                ExtraBed = model.ExtraBed,
                CustomerMessage = model.CustomerMessage,
                ReservationId = latestId,
                
                Type = latestType,

            };

            _db.ReservationsDetails.Add(newResDetails);
            _db.SaveChanges();


            var newReservedRooms = new ReservedRoom()
            {
                ReservationId = latestId,
                RoomId = model.RoomId,
                BookedRooms = model.BookedRooms,

            };

            _db.ReservedRooms.Add(newReservedRooms);
            _db.SaveChanges();


            var Cost = CalculateCost(newReservation, newReservedRooms, newResDetails);
            
            
        }

        
        public object CalculateCost(Reservation reservation, ReservedRoom reservedRoom, ReservationsDetail reservationsDetail)
        {
            double totalprice = 0;
            bool extrabed = (bool)reservationsDetail.ExtraBed;
            var costPerNight = _db.Rooms.FirstOrDefault(x => x.Id == reservedRoom.RoomId).Price;
            DateTime d1 = reservation.StartDate;
            DateTime d2 = reservation.EndDate;
            TimeSpan t = d2 - d1;
            var accomodationTypePrice = _db.Accomodations.FirstOrDefault(x => x.Type == reservationsDetail.Type).Price;
            int days = (int)t.Days;
            int rooms = reservedRoom.BookedRooms;

            var CostPerNightAndRoom = costPerNight * (days*rooms);

            totalprice += CostPerNightAndRoom;

            totalprice += accomodationTypePrice;


            
            


            if (extrabed==true)
            {
                totalprice += 200;
            }


            using (var db = new HolidayMakerContext())
            {
                var result = db.Reservations.SingleOrDefault(b => b.Id == latestId);
                if (result != null)
                {
                    result.TotalPrice = totalprice;
                    db.SaveChanges();
                }
            }


            return totalprice;


            
         
        }
      
        
       

    }
}



//Räkna ut vad det kommer att kosta i bokningen
