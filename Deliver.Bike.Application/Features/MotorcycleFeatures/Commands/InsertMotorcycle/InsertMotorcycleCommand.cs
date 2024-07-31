using Deliver.Bike.Application.Abstractions;

namespace Deliver.Bike.Application.Features.MotorcycleFeatures.Commands.InsertMotorcycle;

public record InsertMotorcycleCommand (
    string Identifier,
    int Year,
    string Model,
    string Plate,
    bool IsAvailable
) : ICommand<Guid>;
