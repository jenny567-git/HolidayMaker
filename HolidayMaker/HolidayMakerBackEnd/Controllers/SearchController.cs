using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerBackEnd.Services;
using HolidayMakerBackEnd.Models.Database;

namespace HolidayMakerBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchService _searchService;

        public SearchController()
        {
            _searchService = new SearchService();
        }

        [HttpGet("Search/getAllHotel")]
        public ActionResult<IEnumerable<Hotel>> GetAllHotels()
        {
            var result = _searchService.GetAllHotel().AsEnumerable();
            return result;
        }
    }
}
