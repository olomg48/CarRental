using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Position : ValueObject
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public string Unit { get; private set; }

        public Position(double x, double y, string unit)
        {
            X = x;
            Y = y;
            Unit = unit;
        }

        public Distance CalculateDistance(Position other)
        {
            if (Unit != other.Unit) throw new InvalidOperationException("Different units");

            double dx = X - other.X;
            double dy = Y - other.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            return new Distance(distance, Unit);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return X;
            yield return Y;
            yield return Unit;
        }
    }

}
