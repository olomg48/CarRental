using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.Commands
{
    public class RentCarCommand
    {
        public long CarId { get; set; }
        public long DriverId { get; set; }

        public RentCarCommand(long carId, long driverId)
        {
            CarId = carId;
            DriverId = driverId;
        }
    }
}
