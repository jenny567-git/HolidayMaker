using HolidayMakerBackEnd.Models.Database;
using HolidayMakerBackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Models.ViewModels
{
    public class AvailableHotelViewModel
    {
        public HotelRoomsViewModel RoomList { get; set; }
        public Hotel Hotel{ get; set; }

        public AvailableHotelViewModel()
        {

        }

        public AvailableHotelViewModel(HotelRoomsViewModel list, Hotel hotel)
        {
            RoomList = list;
            Hotel = hotel;
        }
    }

}
