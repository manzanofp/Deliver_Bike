using Deliver.Bike.Application.Abstractions;

namespace Deliver.Bike.Application.Features.MotorcycleFeatures.Commands.RemoveMotorcycle;

public record RemoveMotorcycleCommand(Guid MotorcycleId): ICommand<string>;
