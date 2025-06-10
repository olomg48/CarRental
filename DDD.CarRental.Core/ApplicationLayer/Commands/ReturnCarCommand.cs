using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.Commands
{
	public class ReturnCarCommand
	{
		public long RentalId { get; set; }
		public double PricePerMinute { get; set; }

		public ReturnCarCommand(long rentalId, double pricePerMinute)
		{
			RentalId = rentalId;
			PricePerMinute = pricePerMinute;
		}
	}
}
