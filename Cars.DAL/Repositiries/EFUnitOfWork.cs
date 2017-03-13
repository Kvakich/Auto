using Cars.DAL.Context;
using Cars.DAL.Entities;
using Cars.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DAL.Repositiries
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AutoContext db;
        private CarRepository carRepository;
        private OrderRepository orderRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new AutoContext(connectionString);
        }
        public IRepository<Car> Cars
        {
            get
            {
                if (carRepository == null)
                    carRepository = new CarRepository(db);
                return carRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
