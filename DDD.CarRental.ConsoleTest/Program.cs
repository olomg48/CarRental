using System;
using Microsoft.Extensions.DependencyInjection;
using DDD.CarRental.Core.ApplicationLayer.Commands;
using DDD.CarRental.Core.ApplicationLayer.Queries;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.InfrastructureLayer.EF;
using DDD.CarRental.Core.ApplicationLayer.Mappers;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using DDD.CarRental.Core.ApplicationLayer.Commands.Handlers;
using DDD.CarRental.Core.ApplicationLayer.Queries.Handlers;
using DDD.SharedKernel.DomainModelLayer;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		var services = new ServiceCollection();
		// Rejestracja EF DbContext
		services.AddDbContext<CarRentalDbContext>();

		// Rejestracja publishera zdarzeń
		services.AddSingleton<IDomainEventPublisher>();

		// Rejestracja repozytoriów
		services.AddScoped<ICarRepository, CarRepository>();
		services.AddScoped<IDriverRepository, DriverRepository>();
		services.AddScoped<IRentalRepository, RentalRepository>();

		// Rejestracja Unit of Work
		services.AddScoped<ICarRentalUnitOfWork, CarRentalUnitOfWork>();

		// Handlery komend
		services.AddTransient<CreateDriverCommandHandler>();
		services.AddTransient<CreateCarCommandHandler>();
		services.AddTransient<RentCarCommandHandler>();
		services.AddTransient<ReturnCarCommandHandler>();

		// Handlery zapytań
		services.AddTransient<GetDriverByIdQueryHandler>();
		services.AddTransient<GetCarByIdQueryHandler>();
		services.AddTransient<GetAllCarsQueryHandler>();

		var provider = services.BuildServiceProvider();

		// 1. Create Driver
		var createDriverHandler = provider.GetService<CreateDriverCommandHandler>();
		createDriverHandler.Handle(new CreateDriverCommand
		(
			licenceNumber: Guid.NewGuid().ToString(),
			firstName: "Jan",
			lastName: "Kowalski"
		));

		// 2. Create Car
		var createCarHandler = provider.GetService<CreateCarCommandHandler>();		
		createCarHandler.Handle(new CreateCarCommand
		(
			registrationNumber: "KR12345",
			x: 10,
			y: 20,
			unit: "km"
		));

		var getCarsHandler = provider.GetService<GetAllCarsQueryHandler>();
		var allCars = getCarsHandler.Handle(new GetAllCarsQuery());
		var carId = allCars.Last().Id;

		var getDriversHandler = provider.GetService<GetAllDriversQueryHandler>();
		var allDrivers = getDriversHandler.Handle(new GetAllDriversQuery());
		var driverId = allDrivers.Last().Id;

		// 3. Start Rental
		var startRentalHandler = provider.GetService<RentCarCommandHandler>();
		startRentalHandler.Handle(new RentCarCommand
		(
			carId: carId,
			driverId: driverId
		));

		var getRentalsHandler = provider.GetService<GetAllRentalsQueryHandler>();
		var allRentals = getRentalsHandler.Handle(new GetAllRentalsQuery());
		var rentalId = allRentals.Last().Id;

		// 4. End Rental
		var endRentalHandler = provider.GetService<ReturnCarCommandHandler>();
		endRentalHandler.Handle(new ReturnCarCommand
		(
			rentalId: rentalId,
			pricePerMinute: 0.5
		));

		// 5. Get Driver
		var driverQueryHandler = provider.GetService<GetDriverByIdQueryHandler>();
		var driverDto = driverQueryHandler.Handle(new GetDriverByIdQuery(driverId));
		Console.WriteLine($"Driver: {driverDto.FirstName} {driverDto.LastName}");

		// 6. Get Car
		var carQueryHandler = provider.GetService<GetCarByIdQueryHandler>();
		var carDto = carQueryHandler.Handle(new GetCarByIdQuery(carId));
		Console.WriteLine($"Car: {carDto.RegistrationNumber}, Status: {carDto.Status}");

		Console.WriteLine("Test scenariusz wykonany pomyślnie");
	}
}