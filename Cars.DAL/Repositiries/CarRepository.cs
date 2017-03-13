using Cars.DAL.Context;
using Cars.DAL.Entities;
using Cars.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DAL.Repositiries
{
    public class CarRepository : IRepository<Car>
    {
        private AutoContext db;

        public CarRepository(AutoContext context)
        {
            this.db = context;
        }

        public IEnumerable<Car> GetAll()
        {
            return db.Cars;
        }
        public Car Get(int id)
        {
            return db.Cars.Find(id);
        }
        public void Create (Car car)
        {
            db.Cars.Add(car);
        }
        public void Update (Car car)
        {
            db.Entry(car).State = EntityState.Modified;
        }

        public IEnumerable<Car> Find(Func<Car, Boolean> predicate)
        {
            return db.Cars.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Car car = db.Cars.Find(id);
            if (car != null)
                db.Cars.Remove(car);
        }
    }
}
