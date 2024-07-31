using Deliver.Bike.Domain.Shared;
using MediatR;

namespace Deliver.Bike.Application.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
