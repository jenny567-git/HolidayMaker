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
        public string FullName { get; set; }
        public string Email { get; set; }


        public LoginResponseViewModel(Guest guest)
        {
            Id = guest.Id;
            FullName = guest.FullName;
            Email = guest.Email;
        }

    }
}
