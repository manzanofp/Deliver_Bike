using FluentValidation;

namespace Deliver.Bike.Application.Features.MotorcycleFeatures.Commands.InsertMotorcycle;

public class InsertMotorcycleValidator : AbstractValidator<InsertMotorcycleCommand>
{
    public InsertMotorcycleValidator()
    {
        RuleFor(x => x.Plate)
            .NotNull()
            .NotEmpty()
            .MaximumLength(7)
            .WithMessage("Field Plate is required!");

        RuleFor(x => x.Identifier)
            .NotNull()
            .NotEmpty()
            .WithMessage("Field Identifier is required!");

        RuleFor(x => x.Year)
            .NotNull()
            .NotEmpty()
            .WithMessage("Field Year is required!");

        RuleFor(x => x.Model)
            .NotNull()
            .NotEmpty()
            .WithMessage("Field Model is required!");
    }
}
