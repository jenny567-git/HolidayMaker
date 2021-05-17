using HolidayMakerBackEnd.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Models.ViewModels
{
    public class BookingInputModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public int? FlightId { get; set; }
        public int HotelId { get; set; }
        public int GuestId { get; set; }


        public ReservedRoom reserved { get; set; }





        //public Guest Guest { get; set; }
        //public Hotel Hotel { get; set; }
        //public virtual ICollection<ReservedRoom> ReservedRooms { get; set; }

    }
}
