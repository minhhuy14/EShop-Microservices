namespace Ordering.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderCommand : ICommand<UpdateOrderResponse>
{
    public OrderDto Order { get; set; }
}

public class UpdateOrderResponse
{
    public Guid Id { get; set; }
}