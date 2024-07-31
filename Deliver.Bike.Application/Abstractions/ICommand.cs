using Deliver.Bike.Domain.Shared;
using MediatR;

namespace Deliver.Bike.Application.Abstractions;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}