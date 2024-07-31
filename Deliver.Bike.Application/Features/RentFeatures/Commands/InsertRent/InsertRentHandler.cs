using Deliver.Bike.Application.Abstractions;
using Deliver.Bike.Domain.Entities.DeliverEntity.ValueObject;
using Deliver.Bike.Domain.Entities.DeliverManEntity.Repositories;
using Deliver.Bike.Domain.Entities.MotorcycleEntity.Repositories;
using Deliver.Bike.Domain.Entities.RentEntity.Repositories;
using Deliver.Bike.Domain.Entities.RentyEntity;
using Deliver.Bike.Domain.Shared;
using Deliver.Bike.Domain.Shared.CalculateRentPrices;
using Microsoft.Extensions.Logging;

namespace Deliver.Bike.Application.Features.RentFeatures.Commands.InsertRent;

public class InsertRentHandler : ICommandHandler<InsertRentCommand, RentResult>
{
    private readonly IMotorcycleRepository _motorcycleRepository;
    private readonly IDeliverManRepository _deliverManRepository;
    private readonly IRentRepository _rentRepository;
    private readonly ILogger<InsertRentHandler> _logger;
    private readonly ICalculateRentPrice _calculatePrices;

    public InsertRentHandler(IMotorcycleRepository motorcycleRepository, IDeliverManRepository deliverManRepository,IRentRepository rentRepository, ILogger<InsertRentHandler> logger, ICalculateRentPrice calculatePrice)
    {
        _motorcycleRepository = motorcycleRepository;
        _deliverManRepository = deliverManRepository;
        _rentRepository = rentRepository;
        _logger = logger;
        _calculatePrices = calculatePrice;
    }

    public async Task<Result<RentResult>> Handle(InsertRentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var availableMotorcycle = await _motorcycleRepository.GetAvailable();
            if (availableMotorcycle == null)
            {
                _logger.LogError("no motorcycles available for rent!");
                return new Error("no motorcycles available for rent!");
            }

            var availableDeliverMan = await _deliverManRepository.GetAvailableForRent(request.DeliverManId);
            if (availableDeliverMan == null)
            {
                _logger.LogError($"no DeliverMan available for rent by Id: {request.DeliverManId}");
                return new Error($"no DeliverMan available for rent by Id: {request.DeliverManId}");
            }

            if(availableDeliverMan.Rents.Any(x => x.IsActive))
            {
                _logger.LogError($"DeliverMan with id have active rent: {request.DeliverManId}");
                return new Error($"DeliverMan with id have active rent: {request.DeliverManId}");
            }

            if (availableDeliverMan.CnhType == CnhEnum.B)
            {
                _logger.LogError($"DeliverMan by Id: {request.DeliverManId} no have CNH type A");
                return new Error($"DeliverMan by Id: {request.DeliverManId} no have CNH type A");
            }

            var rentCalculateValue = _calculatePrices.CalculateRent(DateTimeOffset.UtcNow, request.EndDate, request.ExpectedEndDate, request.RentPlan);

            var rent = new Rent(
                availableDeliverMan.Id,
                availableMotorcycle.Id,
                DateTimeOffset.UtcNow.Date,
                request.EndDate,
                request.ExpectedEndDate,
                rentCalculateValue,
                request.RentPlan,
                true);

            rent.Motorcycle = availableMotorcycle;
            rent.DeliverMan = availableDeliverMan;
            _rentRepository.Add(rent);
            await _rentRepository.SaveChangesAsync(cancellationToken);

            availableMotorcycle.IsAvailable = false;
            _motorcycleRepository.Update(availableMotorcycle);
            await _motorcycleRepository.SaveChangesAsync(cancellationToken);

            availableDeliverMan?.Rents?.Add(rent);
            await _deliverManRepository.SaveChangesAsync(cancellationToken);

            var locationResult = new RentResult(
                rent.Id,
                rent.DeliverManId,
                rent.MotorcycleId,
                rent.InitDate,
                rent.EndDate,
                rent.ExpectedEndDate,
                rent.Value);

            return Result.Success(locationResult);
        } 
        catch (Exception ex)
        {
            _logger.LogError($"Unable to create a rent: {ex.Message}");
            return new Error($"Unable to create a rent: {ex.Message}");
        }
    }
}
