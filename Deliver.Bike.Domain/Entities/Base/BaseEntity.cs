using Deliver.Bike.Domain.Contracts;

namespace Deliver.Bike.Domain.Entities.Base;

public abstract class BaseEntity : IEntity<Guid>
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
}
