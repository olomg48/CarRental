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
    public class GetRentalByIdQueryHandler
    {
        private readonly ICarRentalUnitOfWork _unitOfWork;

        public GetRentalByIdQueryHandler(ICarRentalUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RentalDto Handle(GetRentalByIdQuery query)
        {
            var rental = _unitOfWork.RentalRepository.GetById(query.Id);
            return rental != null ? Mapper.MapToDto(rental) : null;
        }
    }
}
