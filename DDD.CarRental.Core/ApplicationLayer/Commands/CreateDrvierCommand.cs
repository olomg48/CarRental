using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.Commands
{
    public class CreateDriverCommand
    {
        public string LicenceNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CreateDriverCommand(string licenceNumber, string firstName, string lastName)
        {
            LicenceNumber = licenceNumber;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
