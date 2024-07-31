using Deliver.Bike.Domain.Entities.DeliverEntity;
using Deliver.Bike.Domain.Entities.DeliverManEntity.Repositories;
using Deliver.Bike.Persistence.Context;
using Deliver.Bike.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Deliver.Bike.Persistence.Repositories;

public class DeliveryManRepository : BaseRepository<DeliverMan, Guid>, IDeliverManRepository
{
    public DeliveryManRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public Task<DeliverMan?> GetByCnh(string Cnh) => Get().Where(x => x.CnhNumber == Cnh).FirstOrDefaultAsync();
    public Task<DeliverMan?> GetByCnpj(string Cnpj) => Get().Where(x => x.Cnpj == Cnpj).FirstOrDefaultAsync();

    public Task<DeliverMan?> GetAvailableForRent(Guid id)
    {
        return Get()
        .Where(x => x.Id == id)
        .Include(x => x.Rents)
        .FirstOrDefaultAsync();
    }

    public Task<DeliverMan?> GetById(Guid id) => Get().Where(x => x.Id == id).FirstOrDefaultAsync();
}
