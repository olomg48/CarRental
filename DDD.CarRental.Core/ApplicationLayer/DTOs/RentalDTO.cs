using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.DTOs
{
    public class RentalDto
    {
        public long Id { get; set; }
        public long CarId { get; set; }
        public long DriverId { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Finished { get; set; }
        public decimal? Total { get; set; }
        public string Currency { get; set; }
    }
}
