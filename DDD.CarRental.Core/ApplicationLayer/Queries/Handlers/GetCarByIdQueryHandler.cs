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
    public class GetCarByIdQueryHandler
    {
        private readonly ICarRentalUnitOfWork _unitOfWork;

        public GetCarByIdQueryHandler(ICarRentalUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CarDto Handle(GetCarByIdQuery query)
        {
            var car = _unitOfWork.CarRepository.GetById(query.Id);
            return car != null ? Mapper.MapToDto(car) : null;
        }
    }
}
