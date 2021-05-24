using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HolidayMakerBackEnd.Models.Database
{
    public partial class ReservedRoom
    {
        public int ReservationId { get; set; }
      
        public int RoomId { get; set; }
        public int BookedRooms { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual Room Room { get; set; }
    }
}
