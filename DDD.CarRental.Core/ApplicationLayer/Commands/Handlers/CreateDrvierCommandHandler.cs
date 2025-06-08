using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.Commands.Handlers
{
    public class CreateDriverCommandHandler
    {
        private readonly ICarRentalUnitOfWork _unitOfWork;

        public CreateDriverCommandHandler(ICarRentalUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle(CreateDriverCommand command)
        {
            var driver = new Driver(command.LicenceNumber, command.FirstName, command.LastName);

            _unitOfWork.DriverRepository.Add(driver);
            _unitOfWork.Commit();
        }
    }
}
