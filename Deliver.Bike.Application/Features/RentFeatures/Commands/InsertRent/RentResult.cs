namespace Deliver.Bike.Application.Features.RentFeatures.Commands.InsertRent;

public record RentResult(
     Guid RentId,
     Guid DeliverManId,
     Guid MotorcycleId,
     DateTimeOffset InitDate,
     DateTimeOffset EndDate,
     DateTimeOffset ExpectedEndDate,
     decimal Value
);
