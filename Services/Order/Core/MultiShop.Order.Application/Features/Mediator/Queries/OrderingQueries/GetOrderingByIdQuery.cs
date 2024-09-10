﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderinResults;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
	public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
	{
        public int Id { get; set; }
		public GetOrderingByIdQuery(int id)
		{
			Id = id;
		}
	}
}