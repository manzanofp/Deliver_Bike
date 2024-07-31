using Deliver.Bike.Domain.Entities.Base;
using Deliver.Bike.Domain.Entities.RentyEntity;

namespace Deliver.Bike.Domain.Entities.MotorcycleEntity;

public class Motorcycle : BaseEntity
{

    private Motorcycle() { }

    public Motorcycle(string identifier,
        int year,
        string model,
        string plate,
        bool isAvailable)
    {
        Identifier = identifier;
        Year = year;
        Model = model;
        Plate = plate;
        IsAvailable = isAvailable;
    }

    #region Properties
    public string Identifier { get; set; }
    public int Year { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }
    public bool IsAvailable { get; set; }

    #endregion

    #region Relationships
    public IList<Rent> Rents { get; set; }
    #endregion

}
