﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackEnd.Models.ViewModels
{
    public class LoginRequestViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}
