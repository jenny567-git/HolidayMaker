using HolidayMakerBackEnd.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Models.ViewModels
{
    public class GuestAllBookingsViewModel
    {

        //Guest
        public string FullName { get; set; }

        public IEnumerable<Reservation>Reservations { get; set; }
        public IEnumerable<ReservationsDetail> ReservationsDetails { get; set; }

        


        //ReservationDetails
        public int Adults { get; set; }
        public int? Children { get; set; }
        public bool? ExtraBed { get; set; }
        public string CustomerMessage { get; set; }
        public int ReservationId { get; set; }
        public string Type { get; set; }



        //ReservedRRoms
        //public List<ReservedRoom> ReservedRooms = new List<ReservedRoom>();
        public int NumberOfRooms { get; set; }

        public GuestAllBookingsViewModel(IEnumerable<Reservation> reservations)
        {
            Reservations = reservations;
        }
        public GuestAllBookingsViewModel()
        {

        }

        
    }
}
