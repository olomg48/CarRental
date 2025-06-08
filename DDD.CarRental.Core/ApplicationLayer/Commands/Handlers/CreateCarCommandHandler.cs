using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.Commands.Handlers
{
    public class CreateCarCommandHandler
    {
        private readonly ICarRentalUnitOfWork _unitOfWork;

        public CreateCarCommandHandler(ICarRentalUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle(CreateCarCommand command)
        {
            var position = new Position(command.X, command.Y, command.Unit);
            var car = new Car(command.RegistrationNumber, position);

            _unitOfWork.CarRepository.Add(car);
            _unitOfWork.Commit();
        }
    }
}
