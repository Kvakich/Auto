using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public class OrderViewModel
    {
        public int CarId { get; set; }
        public string Address { get; set; }
        public string CarNumber { get; set; } 
    }
}