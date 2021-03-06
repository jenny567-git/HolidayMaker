using HolidayMakerBackEnd.Models.Database;
using HolidayMakerBackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Models.ViewModels
{
    public class ReservationViewModel
    {
        //Guest
        public string FullName { get; set; }
        public CustomerDetailsModel GuestDetails { get; set; } = new();

        //reservation
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Status { get; set; }
        public string HotelImg { get; set; }


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
        public string RoomType { get; set; }

        public HotelRoomsViewModel hotelRoomsViewModel = new HotelRoomsViewModel();
        //public RoomTypeViewModel RoomTypeViewModel = new RoomTypeViewModel();

        public ReservationViewModel()
        {
           

        }

    }
}
