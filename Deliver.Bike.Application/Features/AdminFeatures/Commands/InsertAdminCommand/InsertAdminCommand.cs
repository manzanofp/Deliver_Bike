using Deliver.Bike.Application.Abstractions;

namespace Deliver.Bike.Application.Features.AdminFeatures.Commands.InsertAdminCommand;

public record InsertAdminCommand(
    ) : ICommand<Guid>
{
}
