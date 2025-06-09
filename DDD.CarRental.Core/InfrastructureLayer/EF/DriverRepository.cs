using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DDD.CarRental.Core.InfrastructureLayer.EF
{
    public class DriverRepository : IDriverRepository
    {
        private readonly CarRentalDbContext _context;

        public DriverRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public void Add(Driver entity) => _context.Drivers.Add(entity);

        public Driver GetById(long id) => _context.Drivers.Find(id);

        public IEnumerable<Driver> GetAll() => _context.Drivers.ToList();
    }
}
