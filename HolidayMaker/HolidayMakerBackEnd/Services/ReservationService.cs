using HolidayMakerBackEnd.Models.Database;
using HolidayMakerBackEnd.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Services
{
    public class ReservationService
    {
        private readonly HolidayMakerContext _db;
        public ReservationService()
        {
            _db = new HolidayMakerContext();
        }

        public IEnumerable<Reservation> FindReservation(int id)
        {
            return _db.Reservations.Where(x => x.GuestId == id).AsEnumerable();
        }
        
       
        public IEnumerable<ReservationsDetail> FindReservationDetails(int id)
        {
            return _db.ReservationsDetails.Where(x => x.ReservationId == id).AsEnumerable();
        }

        
    }
}
