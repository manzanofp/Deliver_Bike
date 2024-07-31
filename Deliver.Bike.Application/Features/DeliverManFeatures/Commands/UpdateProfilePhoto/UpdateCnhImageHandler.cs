using Deliver.Bike.Application.Abstractions;
using Deliver.Bike.Domain.Entities.DeliverManEntity.Repositories;
using Deliver.Bike.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Deliver.Bike.Application.Features.DeliverManFeatures.Commands.UpdateProfilePhoto;

public class UpdateCnhImageHandler : ICommandHandler<UpdateCnhImageCommand, string>
{
    private readonly IDeliverManRepository _deliveryManRepository;
    private readonly ILogger<UpdateCnhImageHandler> _logger;

    public UpdateCnhImageHandler(IDeliverManRepository deliveryManRepository, ILogger<UpdateCnhImageHandler> logger)
    {
        _deliveryManRepository = deliveryManRepository;
        _logger = logger;
    }

    public async Task<Result<string>> Handle(UpdateCnhImageCommand request, CancellationToken cancellationToken)
    {
        var deliverMan = await _deliveryManRepository.GetById(request.DeliverManId);
        if (deliverMan == null)
        {
            _logger.LogWarning($"DeliverMan with id: {request.DeliverManId} not found");
            return Result.WithError<string>($"DeliverMan with id: {request.DeliverManId} not found");
        }

        deliverMan.UpdateCnhImage(request.Url);

        await _deliveryManRepository.SaveChangesAsync(cancellationToken);
        return Result.Success($"Update CNH image!");
    }
}
