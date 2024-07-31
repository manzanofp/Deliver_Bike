using FluentValidation;

namespace Deliver.Bike.Application.Features.MotorcycleFeatures.Commands.UpdateMotorcyclePlate;

public class UpdateMotorcyclePlateValidator : AbstractValidator<UpdateMotorcyclePlateCommand>
{
    public UpdateMotorcyclePlateValidator()
    {
        RuleFor(x => x.MotorcycleId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.NewPlate)
            .NotEmpty()
            .NotNull();
    }
}
