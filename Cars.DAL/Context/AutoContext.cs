using Cars.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DAL.Context
{
    public class AutoContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }

        static AutoContext()
        {
            Database.SetInitializer<AutoContext>(new StoreDbInitializer());
        }
        public AutoContext(string connectionString) : 
            base(connectionString)
        { }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<AutoContext>
    {
        protected override void Seed(AutoContext db)
        {
            db.Cars.Add(new Car { Name = "Porshe", Country = "Germany", Price = 3000 });
            db.Cars.Add(new Car { Name = "Lada", Country = "Ukraine", Price = 400 });
            db.Cars.Add(new Car { Name = "BMW", Country = "Belgium", Price = 2000 });
            db.Cars.Add(new Car { Name = "Opel", Country = "Austria", Price = 1000 });
            db.SaveChanges();
        }
    }

}
