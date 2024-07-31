using Deliver.Bike.Application.Abstractions;

namespace Deliver.Bike.Application.Features.DeliverManFeatures.Commands.UpdateProfilePhoto;

public record UpdateCnhImageCommand(
    Guid DeliverManId,
    string Url) : ICommand<string>;
