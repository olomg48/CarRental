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
    public class GetAllRentalsQueryHandler
    {
        private readonly ICarRentalUnitOfWork _unitOfWork;

        public GetAllRentalsQueryHandler(ICarRentalUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<RentalDto> Handle(GetAllRentalsQuery query)
        {
            var rentals = _unitOfWork.RentalRepository.GetAll();
            return rentals.Select(Mapper.MapToDto).ToList();
        }
    }
}
