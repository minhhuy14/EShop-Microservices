using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;

public class GetOrdersQuery(PaginationRequest request) : IQuery<GetOrdersResult>
{
   public PaginationRequest Request { get; set; }= request;
}

public class GetOrdersResult
{
   public PaginatedResult<OrderDto> Orders { get; set; }
}
