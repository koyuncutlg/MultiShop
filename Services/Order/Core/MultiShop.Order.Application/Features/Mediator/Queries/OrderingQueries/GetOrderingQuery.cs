using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderinResults;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
	public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
	{

	}
}