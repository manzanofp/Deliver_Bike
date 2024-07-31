using Deliver.Bike.Application.Abstractions;
using Deliver.Bike.Domain.Entities.MotorcycleEntity;
using Deliver.Bike.Domain.Entities.MotorcycleEntity.Repositories;
using Deliver.Bike.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Deliver.Bike.Application.Features.MotorcycleFeatures.Commands.UpdateMotorcyclePlate;
public class UpdateMotorcyclePlateHandler : ICommandHandler<UpdateMotorcyclePlateCommand, string>
{
    private readonly IMotorcycleRepository _motorcycleRepository;
    private readonly ILogger<UpdateMotorcyclePlateHandler> _logger;

    public UpdateMotorcyclePlateHandler(IMotorcycleRepository motorcycleRepository, ILogger<UpdateMotorcyclePlateHandler> logger)
    {
        _motorcycleRepository = motorcycleRepository;
        _logger = logger;
    }

    public async Task<Result<string>> Handle(UpdateMotorcyclePlateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Motorcycle? motorcycle = await _motorcycleRepository.GetById(request.MotorcycleId);
            if (motorcycle == null)
            {
                _logger.LogWarning($"Motorcycle with id: {request.MotorcycleId} not found");
                return Result.WithError<string>($"Motorcycle with id: {request.MotorcycleId} not found");
            }

            motorcycle.Plate = request.NewPlate;

            await _motorcycleRepository.SaveChangesAsync(cancellationToken);

            return Result.Success("Motorcycle Plate updated successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error when update Motorcycle plate with id: {request.MotorcycleId}: {ex.Message}");
            return Result.WithError<string>($"Error when update Motorcycle plate: {ex.Message}");
        }
    }
}
