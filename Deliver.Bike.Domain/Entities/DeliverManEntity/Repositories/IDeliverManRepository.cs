using Deliver.Bike.Domain.Contracts;
using Deliver.Bike.Domain.Entities.DeliverEntity;

namespace Deliver.Bike.Domain.Entities.DeliverManEntity.Repositories;
public interface IDeliverManRepository : IBaseRepository<DeliverMan, Guid>
{
    Task<DeliverMan?> GetById(Guid id);
    Task<DeliverMan?> GetAvailableForRent(Guid id);
    Task<DeliverMan?> GetByCnh(string Cnh); 
    Task<DeliverMan?> GetByCnpj(string Cnpj);
}
