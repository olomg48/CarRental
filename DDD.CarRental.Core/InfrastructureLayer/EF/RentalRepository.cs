using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DDD.CarRental.Core.InfrastructureLayer.EF
{
    public class RentalRepository : IRentalRepository
    {
        private readonly CarRentalDbContext _context;

        public RentalRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public void Add(Rental entity) => _context.Rentals.Add(entity);

        public Rental GetById(long id) => _context.Rentals.Find(id);

        public IEnumerable<Rental> GetAll() => _context.Rentals.ToList();
    }
}
