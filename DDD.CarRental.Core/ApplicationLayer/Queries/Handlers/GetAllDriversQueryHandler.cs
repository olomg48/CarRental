using DDD.CarRental.Core.ApplicationLayer.DTOs;
using DDD.CarRental.Core.ApplicationLayer.Mappers;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CarRental.Core.ApplicationLayer.Queries.Handlers
{
    public class GetAllDriversQueryHandler
    {
        private readonly ICarRentalUnitOfWork _unitOfWork;

        public GetAllDriversQueryHandler(ICarRentalUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<DriverDto> Handle(GetAllDriversQuery query)
        {
            var drivers = _unitOfWork.DriverRepository.GetAll();
            return drivers.Select(Mapper.MapToDto).ToList();
        }
    }
}
