using Deliver.Bike.Domain.Entities.RentEntity.Enums;

namespace Deliver.Bike.Domain.Shared.CalculateRentPrices;

public class CalculateRentPrice : ICalculateRentPrice
{
    public decimal CalculateRent(DateTimeOffset initDate, DateTimeOffset endDate, DateTimeOffset expectedEndDate, RentPlanEnum rentPlan)
    {
        int totalDays = (int)(endDate - initDate).TotalDays;

        decimal dailyCost = GetDailyCost(rentPlan);

        decimal totalCost = totalDays * dailyCost;

        if (endDate > expectedEndDate)
        {
            totalCost += CalculatePenalty(endDate, expectedEndDate, rentPlan);
        }

        return totalCost;
    }

    private decimal GetDailyCost(RentPlanEnum rentPlan)
    {
        switch (rentPlan)
        {
            case RentPlanEnum.SevenDays:
                return 30.00m;
            case RentPlanEnum.FifteenDays:
                return 28.00m;
            case RentPlanEnum.ThirtyDays:
                return 22.00m;
            case RentPlanEnum.FortyFive:
                return 20.00m;
            case RentPlanEnum.FiftyDays:
                return 18.00m;
            default:
                throw new ArgumentException("Invalid Rent Plan.");
        }
    }

    private decimal CalculatePenalty(DateTimeOffset endDate, DateTimeOffset expectedEndDate, RentPlanEnum rentPlan)
    {
        if (endDate < expectedEndDate)
        {
            int extraDays = (int)(expectedEndDate - endDate).TotalDays;

            decimal dailyCost = GetDailyCost(rentPlan);

            decimal penaltyRate = 0;
            switch (rentPlan)
            {
                case RentPlanEnum.SevenDays:
                    penaltyRate = 0.2m;
                    break;
                case RentPlanEnum.FifteenDays:
                    penaltyRate = 0.4m;
                    break;
                default:
                    throw new ArgumentException("Invalid Rent Plan for penalty calculation.");
            }

            decimal penalty = penaltyRate * dailyCost * extraDays;

            return penalty;
        }
        else if (endDate > expectedEndDate)
        {
            int additionalDays = (int)(endDate - expectedEndDate).TotalDays;

            decimal additionalCostPerDay = 50.00m;

            decimal additionalCost = additionalDays * additionalCostPerDay;

            return additionalCost;
        }
        else
        {
            return 0m;
        }
    }
}
