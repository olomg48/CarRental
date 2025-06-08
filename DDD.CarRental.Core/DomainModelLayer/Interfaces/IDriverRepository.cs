using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.InfrastructureLayer;
using System.Collections.Generic;

namespace DDD.CarRental.Core.DomainModelLayer.Interfaces
{
    public interface IDriverRepository
    {
        void Add(Driver driver);
        Driver GetById(long id);
        IEnumerable<Driver> GetAll();
    }

}
