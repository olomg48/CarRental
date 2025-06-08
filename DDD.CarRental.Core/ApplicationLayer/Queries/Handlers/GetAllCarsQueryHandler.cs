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
    public class GetAllCarsQueryHandler
    {
        private readonly ICarRentalUnitOfWork _unitOfWork;

        public GetAllCarsQueryHandler(ICarRentalUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<CarDto> Handle(GetAllCarsQuery query)
        {
            var cars = _unitOfWork.CarRepository.GetAll();
            return cars.Select(Mapper.MapToDto).ToList();
        }
    }
}
