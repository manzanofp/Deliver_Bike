using Deliver.Bike.Domain.Entities.RentEntity.Enums;

namespace Deliver.Bike.Domain.Shared.CalculateRentPrices;

public interface ICalculateRentPrice
{
    decimal CalculateRent(DateTimeOffset initDate, DateTimeOffset endDate, DateTimeOffset expectedEndDate, RentPlanEnum rentPlan);
}
