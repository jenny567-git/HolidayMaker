using HolidayMakerBackEnd.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Models.ViewModels
{
    public class ReviewModel
    {

        public float Rating { get; set; }

        public string Description { get; set; }
        public int HotelID { get; set; }
        public int GuestID { get; set; }

        


    }
}
