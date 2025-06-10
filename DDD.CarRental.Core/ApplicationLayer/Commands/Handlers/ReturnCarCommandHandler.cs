using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using System;

namespace DDD.CarRental.Core.ApplicationLayer.Commands.Handlers
{
	public class ReturnCarCommandHandler
	{
		private readonly ICarRentalUnitOfWork _unitOfWork;
		private readonly IPositionService _positionService;

		public ReturnCarCommandHandler(ICarRentalUnitOfWork unitOfWork, IPositionService positionService)
		{
			_unitOfWork = unitOfWork;
			_positionService = positionService;
		}

		public void Handle(ReturnCarCommand command)
		{
			var rental = _unitOfWork.RentalRepository.GetById(command.RentalId);
			if (rental == null) throw new InvalidOperationException("Nie znaleziono wypożyczenia.");

			var car = _unitOfWork.CarRepository.GetById(rental.CarId);
			var driver = _unitOfWork.DriverRepository.GetById(rental.DriverId);
			if (car == null || driver == null) throw new InvalidOperationException("Brak powiązanych danych.");

			var newPosition = _positionService.GetCurrentPosition(car.Id);
			var distance = car.CurrentPosition.CalculateDistance(newPosition);

			car.UpdatePosition(newPosition, distance);
			car.ChangeStatus(CarStatus.Free);

			var now = DateTime.UtcNow;
			rental.FinishRental(now, (decimal)command.PricePerMinute, driver.FreeMinutes);

			var durationMinutes = (int)(now - rental.Started).TotalMinutes;
			var usedFreeMinutes = Math.Min(driver.FreeMinutes, durationMinutes);
			var newFreeMinutes = durationMinutes - usedFreeMinutes;

			driver.AddFreeMinutes(newFreeMinutes);
			_unitOfWork.Commit();
		}
	}
}