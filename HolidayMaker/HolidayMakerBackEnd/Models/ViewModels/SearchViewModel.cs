using HolidayMakerBackEnd.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Models.ViewModels
{
    public class SearchViewModel : Hotel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int NoOfAdults { get; set; }
        public int NoOfChildren { get; set; }

        public int NoOfRooms { get; set; }

        public double TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public int HotelId { get; set; }





        public SearchViewModel()
        {
            
        }


    }
}
