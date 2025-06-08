﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.Queries
{
    public class GetRentalByIdQuery
    {
        public long Id { get; }

        public GetRentalByIdQuery(long id)
        {
            Id = id;
        }
    }
}
