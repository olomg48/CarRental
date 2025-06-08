using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.InfrastructureLayer;
using System.Collections.Generic;

namespace DDD.CarRental.Core.DomainModelLayer.Interfaces
{
    public interface IRentalRepository
    {
        void Add(Rental rental);
        Rental GetById(long id);
        IEnumerable<Rental> GetAll();
    }

}
