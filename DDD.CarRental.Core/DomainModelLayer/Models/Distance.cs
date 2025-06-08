using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Distance : ValueObject
    {
        
        public double Value { get; private set; }
        public string Unit { get; private set; }

        public Distance(double value, string unit)
        {
            Value = value;
            Unit = unit;
        }

        public static Distance operator +(Distance a, Distance b)
        {
            if (a.Unit != b.Unit) throw new InvalidOperationException("Different units");
            return new Distance(a.Value + b.Value, a.Unit);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Unit;
        }
    }
}
