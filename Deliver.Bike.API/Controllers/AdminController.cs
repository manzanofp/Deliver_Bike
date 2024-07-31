using Deliver.Bike.API.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Deliver.Bike.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : DeliverBikeBaseController
{
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator) => _mediator = mediator;

    #region Admin

    #endregion
}
