using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.InfrastructureLayer.Services
{
    public class DummyPositionService : IPositionService
    {

        Position IPositionService.GetCurrentPosition(long carId)
        {
            return new Position(10, 10, "km");
        }
    }
}
