using Microsoft.EntityFrameworkCore;
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public class GetOrdersByCustomerHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResponse>
{
    public async Task<GetOrdersByCustomerResponse> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
    {
        //Get order by customer from db
        //Return result

        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .Where(o => o.CustomerId==CustomerId.Of(query.CustomerId))
            .OrderBy(o => o.OrderName)
            .ToListAsync(cancellationToken);

        return new GetOrdersByCustomerResponse
        {
            Orders = orders.ToOrderDtosList()
        };
    }
    
}