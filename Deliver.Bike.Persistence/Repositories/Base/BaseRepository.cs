using Deliver.Bike.Domain.Contracts;
using Deliver.Bike.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Deliver.Bike.Persistence.Repositories.Base;

public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
{
    private readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(TEntity entity) => _dbContext.Add(entity);

    public IQueryable<TEntity> Get() => _dbContext.Set<TEntity>().AsTracking();

    public IQueryable<TEntity> GetAsNoTracking() => Get().AsNoTrackingWithIdentityResolution();

    public void Remove(TEntity entity) => _dbContext.Remove(entity);

    public Task SaveChangesAsync() => _dbContext.SaveChangesAsync();

    public Task SaveChangesAsync(CancellationToken cancellationToken) => _dbContext.SaveChangesAsync(cancellationToken);

    public void Update(TEntity entity) => _dbContext.Update(entity);
}
