using HolidayMakerBackEnd.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Models.ViewModels
{
    public class LoginResponseViewModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }



        public string FullName { get; set; }
        public string Email { get; set; }


        public LoginResponseViewModel(Guest guest)
        {
            Id = guest.Id;
            FullName = guest.FullName;
            Email = guest.Email;
            Street = guest.Street;
            ZipCode = guest.ZipCode;
            City = guest.City;
            Country = guest.Country;
            Phone = guest.Phone;

        }

    }
}
