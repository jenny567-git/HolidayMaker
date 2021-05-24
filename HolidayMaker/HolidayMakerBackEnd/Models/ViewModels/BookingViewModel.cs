using HolidayMakerBackEnd.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Models.ViewModels
{
    public class BookingViewModel
    {

        public Guest Guest { get; set; }
        public Reservation Reservations { get; set; }
        public IEnumerable<ReservedRoom> ReservedRooms { get; set; }
        public IEnumerable<ReservationsDetail> ReservationsDetails { get; set; }

        public BookingViewModel(Reservation reservation)
        {
            Reservations = reservation;
        }

        
       

    }
}
