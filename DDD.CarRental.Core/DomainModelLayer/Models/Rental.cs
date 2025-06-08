using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Rental : Entity, IAggregateRoot
    {
        public Guid CarId { get; private set; }
        public Guid DriverId { get; private set; }
        public DateTime Started { get; private set; }
        public DateTime? Finished { get; private set; }
        public Money? Total { get; private set; }

        public Rental(Guid carId, Guid driverId)
        {
            CarId = carId;
            DriverId = driverId;
            Started = DateTime.UtcNow;
        }

        public void FinishRental(DateTime finishTime, decimal pricePerMinute, int freeMinutes)
        {
            Finished = finishTime;

            var duration = (int)(Finished.Value - Started).TotalMinutes;
            var paidMinutes = Math.Max(0, duration - freeMinutes);
            var totalAmount = paidMinutes * pricePerMinute;

            Total = new Money(totalAmount, "PLN");
        }
    }

}
