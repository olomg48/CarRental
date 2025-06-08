using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.Queries
{
    public class GetCarByIdQuery
    {
        public long Id { get; }

        public GetCarByIdQuery(long id)
        {
            Id = id;
        }
    }
}
