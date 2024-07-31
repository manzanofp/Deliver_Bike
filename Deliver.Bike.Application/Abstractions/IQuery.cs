using Deliver.Bike.Domain.Shared;
using MediatR;

namespace Deliver.Bike.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
