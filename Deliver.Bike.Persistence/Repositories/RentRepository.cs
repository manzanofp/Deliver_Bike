using Deliver.Bike.Domain.Entities.RentEntity.Repositories;
using Deliver.Bike.Domain.Entities.RentyEntity;
using Deliver.Bike.Persistence.Context;
using Deliver.Bike.Persistence.Repositories.Base;

namespace Deliver.Bike.Persistence.Repositories;
public class RentRepository : BaseRepository<Rent, Guid>, IRentRepository
{
    public RentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
