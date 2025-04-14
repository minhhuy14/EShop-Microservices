namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public class GetOrdersByNameQuery(string orderName) : IQuery<GetOrdersByNameResult>
{
    public string Name { get; set; }= orderName;
}
    
public class GetOrdersByNameResult
{
    public IEnumerable<OrderDto> Orders { get; set; }
}
