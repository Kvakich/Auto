using Auto.BLL.BusinessModel;
using Auto.BLL.DTO;
using Auto.BLL.Infrastructure;
using Auto.BLL.Interfaces;
using AutoMapper;
using Cars.DAL.Entities;
using Cars.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderDTO orderDTO)
        {
            Car car = Database.Cars.Get(orderDTO.CarId);

            // валидация
            if (car == null)
                throw new ValidationException("Машина не найдена", "");
            // применяем скидку
            decimal sum = new Discount(0.1m).GetDiscountedPrice(car.Price);
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDTO.Address,
                CarId = car.Id,
                Sum = sum,
                CarNumber = orderDTO.CarNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        public IEnumerable<CarDTO> GetCars()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            Mapper.Initialize(cfg => cfg.CreateMap<Car, CarDTO>());
            return Mapper.Map<IEnumerable<Car>, List<CarDTO>>(Database.Cars.GetAll());
        }

        public CarDTO GetCar(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id машины", "");
            var car = Database.Cars.Get(id.Value);
            if (car == null)
                throw new ValidationException("Машина не найдена", "");
            // применяем автомаппер для проекции Phone на PhoneDTO
            Mapper.Initialize(cfg => cfg.CreateMap<Car, CarDTO>());
            return Mapper.Map<Car, CarDTO>(car);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
