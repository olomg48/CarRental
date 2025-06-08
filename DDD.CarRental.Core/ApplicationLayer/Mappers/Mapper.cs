using DDD.CarRental.Core.ApplicationLayer.DTOs;
using DDD.CarRental.Core.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.ApplicationLayer.Mappers
{
    public static class Mapper
    {
        public static CarDto MapToDto(Car car)
        {
            return new CarDto
            {
                Id = car.Id,
                RegistrationNumber = car.RegistrationNumber,
                Status = car.Status.ToString(),
                CurrentDistance = car.CurrentDistance.Value,
                TotalDistance = car.TotalDistance.Value,
                PositionX = car.CurrentPosition.X,
                PositionY = car.CurrentPosition.Y,
                Unit = car.CurrentDistance.Unit
            };
        }

        public static DriverDto MapToDto(Driver driver)
        {
            return new DriverDto
            {
                Id = driver.Id,
                LicenceNumber = driver.LicenceNumber,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                FreeMinutes = driver.FreeMinutes
            };
        }

        public static RentalDto MapToDto(Rental rental)
        {
            return new RentalDto
            {
                Id = rental.Id,
                CarId = rental.CarId,
                DriverId = rental.DriverId,
                Started = rental.Started,
                Finished = rental.Finished,
                Total = rental.Total?.Amount,
                Currency = rental.Total?.Currency
            };
        }


    }
}
