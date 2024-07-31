namespace Deliver.Bike.Domain.Contracts;

public interface IEntity
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
}

public interface IEntity<TKey> : IEntity
{
    TKey Id { get; }
}

public interface IEntityActive
{
    bool Active { get; set; }
}