using Deliver.Bike.API.Controllers.Base;
using Deliver.Bike.Application.Features.MotorcycleFeatures.Commands.InsertMotorcycle;
using Deliver.Bike.Application.Features.MotorcycleFeatures.Commands.RemoveMotorcycle;
using Deliver.Bike.Application.Features.MotorcycleFeatures.Commands.UpdateMotorcyclePlate;
using Deliver.Bike.Application.Features.MotorcycleFeatures.Queries;
using Deliver.Bike.Application.Features.MotorcycleFeatures.Queries.GetMotorcycleByPlate;
using Deliver.Bike.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Deliver.Bike.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MotorcycleController : DeliverBikeBaseController
{

    private readonly IMediator _mediator;

    public MotorcycleController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    public async Task<IActionResult> Insert(InsertMotorcycleCommand command, CancellationToken cancellationToken)
    {
        Result<Guid> result = await _mediator.Send(command, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : HandleFailure(result);
    }

    [HttpGet("/{plate}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    public async Task<IActionResult> GetByPlate(string plate, CancellationToken cancellationToken)
    {
        Result<MotorcycleResult> result = await _mediator.Send(new GetMotorcycleByPlateQuery(plate), cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : HandleFailure(result);
    }

    [HttpPut("plate")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    public async Task<IActionResult> UpdateMotorcyclePlate(UpdateMotorcyclePlateCommand command, CancellationToken cancellationToken)
    {
        Result<string> result = await _mediator.Send(command, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : HandleFailure(result);
    }

    [HttpDelete("remove/{motorcycleId:Guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    public async Task<IActionResult> RemoveMotorcycle(Guid motorcycleId, CancellationToken cancellationToken)
    {
        Result<string> result = await _mediator.Send(new RemoveMotorcycleCommand(motorcycleId), cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : HandleFailure(result);
    }
}
