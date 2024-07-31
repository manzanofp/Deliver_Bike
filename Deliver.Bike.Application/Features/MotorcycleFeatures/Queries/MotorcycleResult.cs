namespace Deliver.Bike.Application.Features.MotorcycleFeatures.Queries;

public class MotorcycleResult
{
    public MotorcycleResult(Guid id, string identifier, int year, string model, string plate)
    {
        Id = id;
        Identifier = identifier;
        Year = year;
        Model = model;
        Plate = plate;
    }

    public Guid? Id { get; set; }
    public string? Identifier { get; set; }
    public int? Year { get; set; }
    public string? Model { get; set; }
    public string? Plate { get; set; }
}
