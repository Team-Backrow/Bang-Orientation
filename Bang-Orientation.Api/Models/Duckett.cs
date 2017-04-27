using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bang_Orientation.Api.Models
{
    public class Duckett
    {
        public int DuckettsId { get; set; }
        public string DuckettsType { get; set; }
        public int AccountNumber { get; set; }
        public int CustomerId { get; set; }
    }
}