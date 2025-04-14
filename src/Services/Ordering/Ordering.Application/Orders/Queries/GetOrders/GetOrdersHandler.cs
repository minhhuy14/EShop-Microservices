using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrders;

public class GetOrdersHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        //Get order with pagination from db
        //Return result

        var pageIndex = query.Request.PageIndex;
        var pageSize = query.Request.PageSize;
        
        var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);
        
        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .OrderBy(o => o.OrderName.Value)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);


        return new GetOrdersResult
        {
            Orders = new PaginatedResult<OrderDto>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = totalCount,
                Data = orders.ToOrderDtosList()
            }
        };
    }
    
}