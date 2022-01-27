using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Product_management_arun.Models
{
    public class SignupUser
    {

       
        public int id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}