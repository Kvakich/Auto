using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string CarNumber { get; set; }
        public string Address { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public DateTime Date { get; set; }
    }
}
