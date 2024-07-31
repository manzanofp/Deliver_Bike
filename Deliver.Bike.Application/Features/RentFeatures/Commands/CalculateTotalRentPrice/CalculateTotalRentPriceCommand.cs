using Deliver.Bike.Application.Abstractions;
using Deliver.Bike.Domain.Entities.RentEntity.Enums;

namespace Deliver.Bike.Application.Features.RentFeatures.Commands.CalculateTotalRentPrice;
public record CalculateTotalRentPriceCommand(Guid DeliverManId,
    DateTimeOffset InitDate,
    DateTimeOffset EndDate,
    DateTimeOffset ExpectedEndDate,
    RentPlanEnum RentPlan
    ) : ICommand<decimal>;
