using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Driver : Entity, IAggregateRoot
    {
        public string LicenceNumber { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int FreeMinutes { get; private set; }

        public Driver(string licenceNumber, string firstName, string lastName)
        {
            LicenceNumber = licenceNumber;
            FirstName = firstName;
            LastName = lastName;
            FreeMinutes = 0;
        }

        public void AddFreeMinutes(int minutes)
        {
            FreeMinutes += minutes;
        }
    }
}
