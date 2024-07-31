using FluentValidation;

namespace Deliver.Bike.Application.Features.RentFeatures.Commands.CalculateTotalRentPrice;

public class CalculateTotalRentPriceValidator : AbstractValidator<CalculateTotalRentPriceCommand>
{
    public CalculateTotalRentPriceValidator()
    {
        RuleFor(x => x.InitDate)
            .NotNull()
            .WithMessage("InitDate is required!");

        RuleFor(x => x.EndDate)
            .NotNull()
            .WithMessage("EndDate is required!");

        RuleFor(x => x.ExpectedEndDate)
            .NotNull()
            .WithMessage("ExpectedEndDate is required!");
    }
}
