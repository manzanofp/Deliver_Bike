using Deliver.Bike.Application.Abstractions;
using Deliver.Bike.Domain.Entities.MotorcycleEntity;
using Deliver.Bike.Domain.Entities.MotorcycleEntity.Repositories;
using Deliver.Bike.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Deliver.Bike.Application.Features.MotorcycleFeatures.Commands.InsertMotorcycle;

public class InsertMotorcycleHandler : ICommandHandler<InsertMotorcycleCommand, Guid>
{
    private readonly IMotorcycleRepository _motorcycleRepository;
    private readonly ILogger<InsertMotorcycleHandler> _logger;

    public InsertMotorcycleHandler(IMotorcycleRepository motorcycleRepository, ILogger<InsertMotorcycleHandler> logger)
    {
        _motorcycleRepository = motorcycleRepository;
        _logger = logger;
    }

    public async Task<Result<Guid>> Handle(InsertMotorcycleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existMotorcycle = await _motorcycleRepository.GetByPlate(request.Plate);
            if (existMotorcycle != null)
            {
                _logger.LogError("Unable to register the motorcycle, try with another plate!");
                return Result.WithError<Guid>("Unable to register the motorcycle, try with another plate!");
            }

            var motorcycle = new Motorcycle(
                request.Identifier,
                request.Year,
                request.Model,
                request.Plate,
                request.IsAvailable);

            _motorcycleRepository.Add(motorcycle);
            await _motorcycleRepository.SaveChangesAsync(cancellationToken);

            return Result.Success(motorcycle.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error when trying to save motorcycle data with identifier: {request.Identifier},{ex.Message}");
            return Result.WithError<Guid>($"Error when trying to save motorcycle data with identifier: {request.Identifier},{ex.Message}");
        }
    }
}
