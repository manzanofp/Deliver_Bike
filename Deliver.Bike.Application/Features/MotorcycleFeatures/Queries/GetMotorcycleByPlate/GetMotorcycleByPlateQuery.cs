using Deliver.Bike.Application.Abstractions;

namespace Deliver.Bike.Application.Features.MotorcycleFeatures.Queries.GetMotorcycleByPlate;

public record GetMotorcycleByPlateQuery(string Plate) : IQuery<MotorcycleResult>;
