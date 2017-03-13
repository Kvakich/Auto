using Auto.BLL.DTO;
using Auto.BLL.Infrastructure;
using Auto.BLL.Interfaces;
using AutoMapper;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cars.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<CarDTO> carDTOs = orderService.GetCars();
            Mapper.Initialize(cfg => cfg.CreateMap<CarDTO, CarViewModel>());
            var phones = Mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(carDTOs);
            return View(phones);
        }

        public ActionResult MakeOrder(int? id)
        {
            try
            {
                CarDTO car = orderService.GetCar(id);
                Mapper.Initialize(cfg => cfg.CreateMap<CarDTO, OrderViewModel>()
                    .ForMember("CarId", opt => opt.MapFrom(src => src.Id)));
                var order = Mapper.Map<CarDTO, OrderViewModel>(car);
                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<OrderViewModel, OrderDTO>());
                var orderDto = Mapper.Map<OrderViewModel, OrderDTO>(order);
                orderService.MakeOrder(orderDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }
        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}