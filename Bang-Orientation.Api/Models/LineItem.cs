using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bang_Orientation.Api.Models
{
    public class LineItem
    {
        public int LineItemID  { get; set; }
        public string CustomerOrder { get; set; }
        public int Product { get; set; }
        public int Quantity { get; set; }
    }

} 