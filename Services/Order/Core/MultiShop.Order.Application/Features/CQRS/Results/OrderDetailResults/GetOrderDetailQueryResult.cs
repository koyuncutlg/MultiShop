﻿namespace MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults
{
	public class GetOrderDetailQueryResult
	{
		public int OrderDetailId { get; set; }
		public string ProductId { get; set; }
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public int ProductAmount { get; set; }
		public decimal TotalPrice { get; set; }
		public int OrderingId { get; set; }
	}
}