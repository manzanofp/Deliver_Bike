using Deliver.Bike.Domain.Shared;

namespace Deliver.Bike.Domain.Contracts;

public interface IValidationResult
{
    public Error[] Errors { get; }
}
