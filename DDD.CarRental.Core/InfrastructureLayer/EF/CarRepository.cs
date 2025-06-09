using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.InfrastructureLayer.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DDD.CarRental.Core.InfrastructureLayer.EF
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentalDbContext _context;

        public CarRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public void Add(Car entity) => _context.Cars.Add(entity);

        public Car GetById(long id) => _context.Cars.Find(id);

        public IEnumerable<Car> GetAll() => _context.Cars.ToList();
    }
}
