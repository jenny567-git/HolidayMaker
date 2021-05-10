using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerBackEnd.Models.Database;

namespace HolidayMakerBackEnd.Services
{
    public class SearchService
    {
        private readonly HolidayMakerContext _db;

        public SearchService()
        {
            _db = new HolidayMakerContext();
        }       

        public IEnumerable<Hotel> GetAllHotel()
        {
            return _db.Hotels.AsEnumerable();
        }
    }
}
