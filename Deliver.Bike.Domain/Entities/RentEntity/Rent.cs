using Deliver.Bike.Domain.Entities.Base;
using Deliver.Bike.Domain.Entities.DeliverEntity;
using Deliver.Bike.Domain.Entities.MotorcycleEntity;
using Deliver.Bike.Domain.Entities.RentEntity.Enums;

namespace Deliver.Bike.Domain.Entities.RentyEntity;

public class Rent : BaseEntity
{
    private Rent() { }

    public Rent(
        Guid deliverManId,
        Guid motorcycleId,
        DateTimeOffset initDate,
        DateTimeOffset endDate,
        DateTimeOffset expectedEndDate,
        decimal value,
        RentPlanEnum rentplan,
        bool isActive)
    {
        DeliverManId = deliverManId;
        MotorcycleId = motorcycleId;
        InitDate = initDate;
        EndDate = endDate;
        ExpectedEndDate = expectedEndDate;
        Value = value;
        RentPlan = rentplan;
        IsActive = isActive;
    }


    #region Properties
    public Guid DeliverManId { get; set; }
    public Guid MotorcycleId { get; set; }
    public DateTimeOffset InitDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public DateTimeOffset ExpectedEndDate { get; set; }
    public decimal Value { get; set; }
    public bool IsActive { get; set; }
    #endregion

    #region Relationships

    public Motorcycle? Motorcycle { get; set; }
    public RentPlanEnum? RentPlan { get; set; }
    public DeliverMan DeliverMan { get; set; }

    #endregion
}
