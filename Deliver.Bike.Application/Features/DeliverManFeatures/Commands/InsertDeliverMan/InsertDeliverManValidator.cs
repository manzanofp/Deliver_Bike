using FluentValidation;

namespace Deliver.Bike.Application.Features.DeliverManFeatures.Commands.InsertDeliverMan;
public class InsertDeliverManValidator : AbstractValidator<InsertDeliverManCommand>
{
    public InsertDeliverManValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("the name field cannot be empty");

        RuleFor(x => x.Cnpj)
            .NotEmpty()
            .NotNull()
            .MaximumLength(14)
            .WithMessage("The cnpj field must have a maximum of 14 characters");

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.CnhNumber)
            .NotEmpty()
            .NotNull()
            .MaximumLength(11)
            .WithMessage("The CnhNumber field must have a maximum of 11 characters");

        RuleFor(x => x.CnhType)
            .NotEmpty()
            .NotNull()
            .WithMessage("the name field cannot be empty");
    }
}
