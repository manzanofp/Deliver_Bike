using Deliver.Bike.Application.Abstractions;
using Deliver.Bike.Domain.Entities.RentEntity.Enums;

namespace Deliver.Bike.Application.Features.RentFeatures.Commands.InsertRent;

public record InsertRentCommand(
    Guid DeliverManId,
    DateTimeOffset EndDate,
    DateTimeOffset ExpectedEndDate,
    RentPlanEnum RentPlan
    ) : ICommand<RentResult>;
