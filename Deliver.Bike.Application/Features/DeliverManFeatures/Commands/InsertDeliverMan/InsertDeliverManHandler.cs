using Deliver.Bike.Application.Abstractions;
using Deliver.Bike.Domain.Entities.DeliverEntity;
using Deliver.Bike.Domain.Entities.DeliverManEntity.Repositories;
using Deliver.Bike.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Deliver.Bike.Application.Features.DeliverManFeatures.Commands.InsertDeliverMan;

public class InsertDeliverManHandler : ICommandHandler<InsertDeliverManCommand, Guid>
{
    private readonly IDeliverManRepository _deliveryManRepository;
    private readonly ILogger<InsertDeliverManHandler> _logger;

    public InsertDeliverManHandler(IDeliverManRepository deliveryManRepository, ILogger<InsertDeliverManHandler> logger)
    {
        _deliveryManRepository = deliveryManRepository;
        _logger = logger;
    }

    public async Task<Result<Guid>> Handle(InsertDeliverManCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var cnhExists = await _deliveryManRepository.GetByCnh(request.CnhNumber); 
            if (cnhExists != null)
            {
                _logger.LogError($"DeliverMan with Cnh: {request.CnhNumber} already Exists!");
                return Result.WithError<Guid>($"DeliverMan with Cnh: {request.CnhNumber} already Exists!");
            }

            var cnpjExists = await _deliveryManRepository.GetByCnpj(request.Cnpj);
            if (cnpjExists != null)
            {
                _logger.LogError($"DeliverMan with Cnpj: {request.Cnpj} already Exists!");
                return Result.WithError<Guid>($"DeliverMan with Cnpj: {request.Cnpj} already Exists!");
            }

            var deliverMan = new DeliverMan(
                request.Name,
                request.Cnpj,
                request.BirthDate,
                request.CnhNumber,
                request.CnhType,
                request.CnhImage);

            _deliveryManRepository.Add(deliverMan);
            await _deliveryManRepository.SaveChangesAsync(cancellationToken);

            return Result.Success(deliverMan.Id);
        }  
        catch (Exception ex)
        {
            _logger.LogError($"Error when trying to save DeliverMan data:{request} ,{ex.Message}");
            return Result.WithError<Guid>($"Error when trying to save DeliverMan data:{request}, {ex.Message}");
        }
    }
}
