using Deliver.Bike.Domain.Entities.MotorcycleEntity;
using Deliver.Bike.Domain.Entities.MotorcycleEntity.Repositories;
using Deliver.Bike.Persistence.Context;
using Deliver.Bike.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Deliver.Bike.Persistence.Repositories;
public class MotorcycleRepository : BaseRepository<Motorcycle, Guid>, IMotorcycleRepository
{
    public MotorcycleRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public Task<Motorcycle?> GetAvailable() => Get().Where(x => x.IsAvailable == true).FirstOrDefaultAsync();

    public Task<Motorcycle?> GetById(Guid id) => Get().Where(x => x.Id == id).FirstOrDefaultAsync();

    public Task<Motorcycle?> GetByIdWithRelationships(Guid id)
    {
        return Get()
            .Where(x => x.Id == id)
            .Include(x => x.Rents)
            .FirstOrDefaultAsync();
    }

    public Task<Motorcycle?> GetByPlate(string plate) => Get().Where(x => x.Plate == plate).FirstOrDefaultAsync();

}
