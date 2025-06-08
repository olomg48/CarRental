using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.DTOs
{
    public class CarDto
    {
        public long Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Status { get; set; }
        public double CurrentDistance { get; set; }
        public double TotalDistance { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public string Unit { get; set; }
    }
}
