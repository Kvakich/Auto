using Auto.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.BLL.Interfaces
{
    public interface IOrderService 
    {
        void MakeOrder(OrderDTO orderDTO);
        CarDTO GetCar(int? id);
        IEnumerable<CarDTO> GetCars();
        void Dispose();
    }
}
