using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.BLL.BusinessModel
{
    public class Discount
    {
        public Discount(decimal val)
        {
            this.value = val;
        }
        private decimal value = 0;
        public decimal Value { get { return value; } }
        public decimal GetDiscountedPrice(decimal sum)
        {
            if (DateTime.Now.Day == 1)
                return sum - sum * value;
            return sum;
        }
    }
}
