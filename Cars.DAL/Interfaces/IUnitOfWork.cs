using Cars.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Car> Cars { get; }
        IRepository<Order> Orders { get; }
        void Save(); 
    }
}
