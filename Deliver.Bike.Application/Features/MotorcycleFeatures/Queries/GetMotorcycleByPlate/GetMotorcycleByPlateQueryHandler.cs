using Deliver.Bike.Application.Abstractions;
using Deliver.Bike.Domain.Entities.MotorcycleEntity.Repositories;
using Deliver.Bike.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Deliver.Bike.Application.Features.MotorcycleFeatures.Queries.GetMotorcycleByPlate;

public class GetMotorcycleByPlateQueryHandler : IQueryHandler<GetMotorcycleByPlateQuery, MotorcycleResult>
{
    private readonly IMotorcycleRepository _motorcycleRepository;
    private readonly ILogger<GetMotorcycleByPlateQueryHandler> _logger;

    public GetMotorcycleByPlateQueryHandler(IMotorcycleRepository motorcycleRepository, ILogger<GetMotorcycleByPlateQueryHandler> logger)
    {
        _motorcycleRepository = motorcycleRepository;
        _logger = logger;
    }

    public async Task<Result<MotorcycleResult>> Handle(GetMotorcycleByPlateQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var motorcycleByPlate = await _motorcycleRepository.GetByPlate(request.Plate);
            if (motorcycleByPlate == null)
            {
                _logger.LogWarning($"Motorcycle with plate: {request.Plate} not found.");
                return new Error($"Motorcycle with plate: {request.Plate} not found.");
            }

            var result = new MotorcycleResult(
                motorcycleByPlate.Id,
                motorcycleByPlate.Identifier,
                motorcycleByPlate.Year,
                motorcycleByPlate.Model,
                motorcycleByPlate.Plate);

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error when search Motorcycle with plate: {request.Plate}: {ex.Message}");
            return new Error($"Error when search Motorcycle by plate: {ex.Message}");
        }
    }
}
