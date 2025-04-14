using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;

public class GetOrdersQuery : IQuery<GetOrdersResponse>
{
   public PaginationRequest Request { get; set; }
}

public class GetOrdersResponse
{
   public PaginatedResult<OrderDto> Orders { get; set; }
}
