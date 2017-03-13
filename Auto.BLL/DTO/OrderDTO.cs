using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string CarNumber { get; set; }
        public string Address { get; set; }

        public int CarId { get; set; }

        public DateTime? Date { get; set; }
    }
}
