using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.InfrastructureLayer.EF
{
    public class PositionService : IPositionService
    {
        private readonly Random _random = new();

        public Position GetCurrentPosition(long carId)
        {
            // Losowa pozycja w zakresie 0–100
            double x = _random.NextDouble() * 100;
            double y = _random.NextDouble() * 100;
            return new Position(x, y, "km");
        }
    }
}
