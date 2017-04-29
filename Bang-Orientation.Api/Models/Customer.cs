using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bang_Orientation.Api.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}