using Deliver.Bike.API.Controllers.Base;
using Deliver.Bike.Application.Features.RentFeatures.Commands.CalculateTotalRentPrice;
using Deliver.Bike.Application.Features.RentFeatures.Commands.InsertRent;
using Deliver.Bike.Domain.Entities.RentEntity.Enums;
using Deliver.Bike.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Deliver.Bike.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentController : DeliverBikeBaseController
{
    private readonly IMediator _mediator;

    public RentController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    public async Task<IActionResult> Insert(InsertRentCommand command, CancellationToken cancellationToken)
    {
        Result<RentResult> result = await _mediator.Send(command, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : HandleFailure(result);
    }

    [HttpGet("calculate")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    public async Task<IActionResult> CalculateTotalPriceRent( Guid deliveryManId, DateTimeOffset initDate, DateTimeOffset endDate, DateTimeOffset expectedEndDate, RentPlanEnum rentPlan, CancellationToken cancellationToken)
    {
        Result<decimal> result = await _mediator.Send(new CalculateTotalRentPriceCommand(deliveryManId, initDate, endDate, expectedEndDate, rentPlan), cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : HandleFailure(result);
    }
}
