using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public enum CarStatus
    {
        Free = 0,
        Reserved = 1,
        Rented = 2
    }

    public class Car : Entity, IAggregateRoot
    {
        public string RegistrationNumber { get; private set; }
        public Distance CurrentDistance { get; private set; }
        public Distance TotalDistance { get; private set; }
        public Position CurrentPosition { get; private set; }
        public CarStatus Status { get; private set; }

        public Car(string registrationNumber, Position initialPosition)
        {
            RegistrationNumber = registrationNumber;
            CurrentDistance = new Distance(0, "km");
            TotalDistance = new Distance(0, "km");
            CurrentPosition = initialPosition;
            Status = CarStatus.Free;
        }

        public void UpdatePosition(Position newPosition, Distance distanceTravelled)
        {
            CurrentPosition = newPosition;
            CurrentDistance = CurrentDistance + distanceTravelled;
            TotalDistance = TotalDistance + distanceTravelled;
        }

        public void ChangeStatus(CarStatus status)
        {
            Status = status;
        }
    }

}
