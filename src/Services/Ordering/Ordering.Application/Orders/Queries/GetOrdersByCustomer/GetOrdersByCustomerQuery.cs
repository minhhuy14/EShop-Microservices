namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public class GetOrdersByCustomerQuery(Guid customerId) : IQuery<GetOrdersByCustomerResult>
{
    public Guid CustomerId { get; set; }= customerId;
}

public class GetOrdersByCustomerResult
{
    public IEnumerable<OrderDto> Orders { get; set; }
}
