using HolidayMakerBackEnd.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Models.ViewModels
{
    public class BookingViewModel
    {
        //Guest
        public string FullName { get; set; }
        

        //reservation
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        
        public int HotelId { get; set; }
        

        //ReservationDetails
        public int Adults { get; set; }
        public int? Children { get; set; }
        public bool? ExtraBed { get; set; }
        public string CustomerMessage { get; set; }
        public int ReservationId { get; set; }
        public string Type { get; set; }


        //ReservedRRoms
        public IEnumerable<ReservedRoom> ReservedRooms = new List<ReservedRoom>();


        public BookingViewModel()
        {
           

        }

    }
}
