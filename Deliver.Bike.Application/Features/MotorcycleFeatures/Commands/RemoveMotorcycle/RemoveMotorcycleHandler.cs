using Deliver.Bike.Application.Abstractions;
using Deliver.Bike.Domain.Entities.MotorcycleEntity;
using Deliver.Bike.Domain.Entities.MotorcycleEntity.Repositories;
using Deliver.Bike.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Deliver.Bike.Application.Features.MotorcycleFeatures.Commands.RemoveMotorcycle;

public class RemoveMotorcycleHandler : ICommandHandler<RemoveMotorcycleCommand, string>
{
    private readonly IMotorcycleRepository _motorcycleRepository;
    private readonly ILogger<RemoveMotorcycleHandler> _logger;

    public RemoveMotorcycleHandler(IMotorcycleRepository motorcycleRepository, ILogger<RemoveMotorcycleHandler> logger)
    {
        _motorcycleRepository = motorcycleRepository;
        _logger = logger;
    }

    public async Task<Result<string>> Handle(RemoveMotorcycleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Motorcycle? motorcycle = await _motorcycleRepository.GetByIdWithRelationships(request.MotorcycleId);
            if (motorcycle == null)
            {
                _logger.LogWarning($"Motorcycle with id: {request.MotorcycleId} not found");
                return Result.WithError<string>($"Motorcycle with id: {request.MotorcycleId} not found");
            }

            if(motorcycle.Rents.Any() == true)
            {
                _logger.LogWarning($"Motorcycle with id: {request.MotorcycleId} have rents registration");
                return Result.WithError<string>($"Motorcycle with id: {request.MotorcycleId} have rents registration");
            }

            _motorcycleRepository.Remove(motorcycle);
            await _motorcycleRepository.SaveChangesAsync(cancellationToken);

            return Result.Success("Motorcycle Removed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error when remove Motorcycle with id: {request.MotorcycleId}: {ex.Message}");
            return Result.WithError<string>($"Error when remove Motorcycle with id: {ex.Message}");
        }
    }
}
