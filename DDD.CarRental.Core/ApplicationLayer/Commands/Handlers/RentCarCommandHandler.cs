using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.Commands.Handlers
{
    public class RentCarCommandHandler
    {
        private readonly ICarRentalUnitOfWork _unitOfWork;

        public RentCarCommandHandler(ICarRentalUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle(RentCarCommand command)
        {
            var car = _unitOfWork.CarRepository.GetById(command.CarId);
            var driver = _unitOfWork.DriverRepository.GetById(command.DriverId);

            if (car == null || driver == null)
                throw new InvalidOperationException("Nie znaleziono kierowcy lub samochodu.");

            if (car.Status != CarStatus.Free)
                throw new InvalidOperationException("Samochód nie jest dostępny.");

            var rental = new Rental(car.Id, driver.Id);

            car.ChangeStatus(CarStatus.Rented);
            _unitOfWork.RentalRepository.Add(rental);
            _unitOfWork.Commit();
        }
    }
}
