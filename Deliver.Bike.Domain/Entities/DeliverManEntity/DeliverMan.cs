using Deliver.Bike.Domain.Entities.Base;
using Deliver.Bike.Domain.Entities.DeliverEntity.ValueObject;
using Deliver.Bike.Domain.Entities.RentyEntity;

namespace Deliver.Bike.Domain.Entities.DeliverEntity;
public class DeliverMan : BaseEntity
{
    public DeliverMan(string name,
        string cnpj,
        DateTimeOffset birthDate,
        string cnhNumber,
        CnhEnum cnhType,
        string? cnhImage)
    {
        Name = name;
        Cnpj = cnpj;
        BirthDate = birthDate;
        CnhNumber = cnhNumber;
        CnhType = cnhType;
        CnhImage = cnhImage;
    }

    private DeliverMan() { }

    #region Properties
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public DateTimeOffset BirthDate { get; set; }
    public string CnhNumber { get; set; }
    public CnhEnum CnhType { get; set; }
    public string? CnhImage { get; set; }

    #endregion

    #region Relationships
    public IList<Rent>? Rents { get; set; }
    #endregion

    public void UpdateCnhImage(string url)
    {
        CnhImage = url;
    }
}
