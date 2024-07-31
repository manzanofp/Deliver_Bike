using FluentValidation;

namespace Deliver.Bike.Application.Features.MotorcycleFeatures.Commands.RemoveMotorcycle;

public class RemoveMotorcycleValidator : AbstractValidator<RemoveMotorcycleCommand>
{
    public RemoveMotorcycleValidator()
    {
        RuleFor(x => x.MotorcycleId)
            .NotEmpty()
            .NotNull()
            .WithMessage("MotorcycleId is required!");
    }
}
