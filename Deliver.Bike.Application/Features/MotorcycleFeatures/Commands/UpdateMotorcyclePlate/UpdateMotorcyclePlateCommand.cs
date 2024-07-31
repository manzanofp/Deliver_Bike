using Deliver.Bike.Application.Abstractions;

namespace Deliver.Bike.Application.Features.MotorcycleFeatures.Commands.UpdateMotorcyclePlate;

public record UpdateMotorcyclePlateCommand(Guid MotorcycleId, string NewPlate) : ICommand<string>;
