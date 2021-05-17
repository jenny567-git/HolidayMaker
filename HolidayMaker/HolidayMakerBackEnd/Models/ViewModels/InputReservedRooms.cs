using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Models.ViewModels
{
    public class InputReservedRooms
    {
        public int ReservationId { get; set; }
        public int RoomId { get; set; }
        public int BookedRooms { get; set; }
    }
}
