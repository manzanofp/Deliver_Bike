using Deliver.Bike.Application.Abstractions;
using Deliver.Bike.Domain.Entities.DeliverManEntity.Repositories;
using Deliver.Bike.Domain.Shared;
using Deliver.Bike.Domain.Shared.CalculateRentPrices;
using Microsoft.Extensions.Logging;

namespace Deliver.Bike.Application.Features.RentFeatures.Commands.CalculateTotalRentPrice;

public class CalculateTotalRentPriceHandler : ICommandHandler<CalculateTotalRentPriceCommand, decimal>
{
    private readonly IDeliverManRepository _deliverManRepository;
    private readonly ILogger<CalculateTotalRentPriceHandler> _logger;
    private readonly ICalculateRentPrice _calculatePrice;

    public CalculateTotalRentPriceHandler(IDeliverManRepository deliveryManRepository, ILogger<CalculateTotalRentPriceHandler> logger, ICalculateRentPrice calculatePrice)
    {
        _deliverManRepository = deliveryManRepository;
        _logger = logger;
        _calculatePrice = calculatePrice;
    }

    public async Task<Result<decimal>> Handle(CalculateTotalRentPriceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var deliverMan = await _deliverManRepository.GetById(request.DeliverManId);
            if (deliverMan == null)
            {
                _logger.LogError($"DeliverMan with id {request.DeliverManId} not found!");
                return new Error($"DeliverMan with id {request.DeliverManId} not found!");
            }

            var totalRentPrice = _calculatePrice.CalculateRent(request.InitDate, request.EndDate, request.ExpectedEndDate, request.RentPlan);

            return Result.Success(totalRentPrice);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error when trying to calculate total price for rent: {ex.Message}");
            return new Error($"Error when trying to calculate total price for rent: {ex.Message}");
        }
    }
}
