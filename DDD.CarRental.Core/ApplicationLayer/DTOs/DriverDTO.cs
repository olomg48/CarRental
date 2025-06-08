﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.DTOs
{
    public class DriverDto
    {
        public long Id { get; set; }
        public string LicenceNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FreeMinutes { get; set; }
    }
}
