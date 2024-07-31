using Deliver.Bike.Domain.Contracts;
using Deliver.Bike.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Deliver.Bike.API.Controllers.Base;

public class DeliverBikeBaseController : ControllerBase
{
    protected IActionResult HandleFailure(Result result)
    {
        return result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),

            IValidationResult validationResult =>
                BadRequest(CreateProblemDetails(
                    "Validation Error",
                    StatusCodes.Status400BadRequest,
                    result.Error,
                    validationResult.Errors)),
            _ =>
                BadRequest(CreateProblemDetails(
                    "Bad Request",
                    StatusCodes.Status400BadRequest,
                    result.Error))
        };
    }

    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null)
    {
        var problemDetails = new ProblemDetails()
        {
            Title = title,
            Detail = error.Message,
            Status = status,
        };

        if (errors is not null)
        {
            problemDetails.Extensions.Add(nameof(errors), errors);
        }

        return problemDetails;
    }
}
