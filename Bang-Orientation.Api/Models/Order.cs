using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bang_Orientation.Api.Models
{
    public class Order
    {
        public string OrderTitle { get; set; }
        public int OrderID { get; set; }

        public int DuckettsID { get; set; }

        public int CustomerID { get; set; }
    }
} 