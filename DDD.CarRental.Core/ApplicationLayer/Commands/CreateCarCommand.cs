using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.Commands
{
    public class CreateCarCommand
    {
        public string RegistrationNumber { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string Unit { get; set; }  // np. "km"

        public CreateCarCommand(string registrationNumber, double x, double y, string unit)
        {
            RegistrationNumber = registrationNumber;
            X = x;
            Y = y;
            Unit = unit;
        }
    }
}
