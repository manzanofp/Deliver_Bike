using Deliver.Bike.Application.Abstractions;
using Deliver.Bike.Domain.Entities.DeliverEntity.ValueObject;

namespace Deliver.Bike.Application.Features.DeliverManFeatures.Commands.InsertDeliverMan;
public record InsertDeliverManCommand(
    string Name,
    string Cnpj,
    DateTimeOffset BirthDate,
    string CnhNumber,
    CnhEnum CnhType,
    string? CnhImage
    ) : ICommand<Guid>;
