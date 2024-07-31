using Deliver.Bike.Domain.Contracts;

namespace Deliver.Bike.Domain.Entities.MotorcycleEntity.Repositories;

public interface IMotorcycleRepository : IBaseRepository<Motorcycle, Guid>
{
    Task<Motorcycle?> GetById(Guid id);
    Task<Motorcycle?> GetByIdWithRelationships(Guid id);
    Task<Motorcycle?> GetByPlate(string plate);
    Task<Motorcycle?> GetAvailable();
}
