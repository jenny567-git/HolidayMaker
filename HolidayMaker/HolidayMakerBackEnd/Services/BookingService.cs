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

        public Reservation GetBookingById(int id)
        {
            
            var result = _db.Reservations.Include(r => r.Guest).Include(h => h.Hotel).ThenInclude(r=>r.Rooms).SingleOrDefault(r => r.Id == id);


            return result;
        }
        public ReservedRoom GetReservedRoom(int id)
        {
            var result = _db.ReservedRooms.FirstOrDefault(x => x.ReservationId == id);
            return result;
        }

        public ReservationsDetail GetReservationsDetail(int id)
        {
            var res = _db.ReservationsDetails.FirstOrDefault(r => r.ReservationId == id);
            return res;

        }
        public IEnumerable<ReservedRoom> GetReservedRooms(int id)
        {
            return _db.ReservedRooms.Where(x => x.ReservationId == id).Include(r=>r.Room).AsEnumerable();

        }
        public IEnumerable<Reservation> GetAllBookingByGuestId(int id)
        {
            var result = _db.Reservations.Where(b => b.GuestId == id).AsEnumerable();
            return result;
        }

        public int CancelBooking(int bookingId)
        {
            var booking = GetBookingById(bookingId);
            var reservedRooms = GetReservedRooms(bookingId);

            foreach(var r in reservedRooms)
            {
                r.BookedRooms = 0;
                _db.ReservedRooms.Update(r);
            }

            booking.Status = "Cancelled";
            _db.Reservations.Update(booking);

            return _db.SaveChanges();
        }

        public int MakeBooking(SearchViewModel model)
        {
            var newReservation = new Reservation()
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                DateCreated = DateTime.Now,
                HotelId = model.HotelId,
                GuestId = model.GuestId,
                FullName = model.customerDetails.FirstName + " " + model.customerDetails.LastName,
                Email = model.customerDetails.Email,
                Phone = model.customerDetails.PhoneNumber,
                Street = model.customerDetails.Street,
                City = model.customerDetails.City,
                Zipcode = model.customerDetails.ZipCode,
                Country = model.customerDetails.Country,
                Status = "Confirmed"
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

            foreach (var reservedRooms in model.ReservedRooms)
            {
                var newReservedRooms = new ReservedRoom()
                {
                    ReservationId = latestId,
                    RoomId = reservedRooms.RoomId,
                    BookedRooms = reservedRooms.BookedRooms,
                };

                _db.ReservedRooms.Add(newReservedRooms);
                _db.SaveChanges();
            }

            var Cost = CalculateCost(newReservation, model.ReservedRooms, newResDetails);
            return latestId;
        }

        
        public double CalculateCost(Reservation reservation, List<ReservedRooms> reservedRooms, ReservationsDetail reservationsDetail)
        {
            double totalprice = 0;
            bool extrabed = (bool)reservationsDetail.ExtraBed;
            List<double> costPerNightForEachRoom = new();
            foreach (var room in reservedRooms)
            {
                costPerNightForEachRoom.Add(_db.Rooms.FirstOrDefault(x => x.Id == room.RoomId).Price);
            }
            DateTime d1 = reservation.StartDate;
            DateTime d2 = reservation.EndDate;
            TimeSpan t = d2 - d1;
            var accomodationTypePrice = _db.Accomodations.FirstOrDefault(x => x.Type == reservationsDetail.Type).Price;
            int days = (int)t.Days;
            int rooms = reservedRooms.Sum(b => b.BookedRooms);

            var CostPerNightAndRoom = costPerNightForEachRoom.Sum() * (days*rooms);

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

        public void UpdateReservation(CustomerDetailsModel model, int id)
        {
            var reservation = _db.Reservations.SingleOrDefault(r => r.Id == id);

            if (reservation != null)
            {
                reservation.FullName = model.FirstName + " " + model.LastName;
                reservation.Email = model.Email;
                reservation.Phone = model.PhoneNumber;
                reservation.Street = model.Street;
                reservation.City = model.City;
                reservation.Zipcode = model.ZipCode;
                reservation.Country = model.Country;

                _db.SaveChanges();
            }
            
        }
    }
}

//Räkna ut vad det kommer att kosta i bokningen