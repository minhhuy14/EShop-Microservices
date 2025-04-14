namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public class GetOrdersByNameQuery : IQuery<GetOrdersByNameResponse>
{
    public string Name { get; set; }
}

public class GetOrdersByNameResponse
{
    public IEnumerable<OrderDto> Orders { get; set; }
}
