using DDD.CarRental.Core.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.DomainModelLayer.Interfaces
{
    public interface IPositionService
    {
        Position GetCurrentPosition(long carId);
    }
}
