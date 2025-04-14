using Microsoft.EntityFrameworkCore;
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public class GetOrdersByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResponse>
{
    public async Task<GetOrdersByNameResponse> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
    {
        //Get order by name from db
        //Return result

        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .Where(o => o.OrderName.Value.ToLower().Contains(query.Name.ToLower()))
            .OrderBy(o => o.OrderName)
            .ToListAsync(cancellationToken);

        return new GetOrdersByNameResponse
        {
            Orders = orders.ToOrderDtosList()
        };
    }
    
}