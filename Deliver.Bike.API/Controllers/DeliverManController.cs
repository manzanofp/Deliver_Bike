using Deliver.Bike.API.Controllers.Base;
using Deliver.Bike.Application;
using Deliver.Bike.Application.Features.DeliverManFeatures.Commands.InsertDeliverMan;
using Deliver.Bike.Application.Features.UploadFileFeatures.Commands.UploadProfilePhoto;
using Deliver.Bike.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Deliver.Bike.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeliverManController : DeliverBikeBaseController
{
    private readonly IMediator _mediator;

    public DeliverManController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    public async Task<IActionResult> Insert(InsertDeliverManCommand command, CancellationToken cancellationToken)
    {
        Result<Guid> result = await _mediator.Send(command, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : HandleFailure(result);
    }

    [HttpPost("{deliverManId:guid}/{uploadType}/upload")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    public async Task<IActionResult> UploadCnhImage(Guid deliverManId, UploadFileTypeEnum uploadType, IFormFile file, CancellationToken cancellationToken)
    {
        Result<string> result = await _mediator.Send(new UploadCnhImageForS3Command(deliverManId, uploadType, file), cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : HandleFailure(result);
    }
}
