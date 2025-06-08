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
    public class GetDriverByIdQueryHandler
    {
        private readonly ICarRentalUnitOfWork _unitOfWork;

        public GetDriverByIdQueryHandler(ICarRentalUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DriverDto Handle(GetDriverByIdQuery query)
        {
            var driver = _unitOfWork.DriverRepository.GetById(query.Id);
            return driver != null ? Mapper.MapToDto(driver) : null;
        }
    }
}
