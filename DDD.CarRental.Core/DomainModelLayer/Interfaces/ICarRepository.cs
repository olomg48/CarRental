﻿using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.InfrastructureLayer;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Interfaces
{
    public interface ICarRepository
    {
        void Add(Car car);
        Car GetById(long id);
        IEnumerable<Car> GetAll();
    }
}
