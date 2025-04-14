namespace Ordering.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderCommand : ICommand<UpdateOrderResult>
{
    public OrderDto Order { get; set; }
}

public class UpdateOrderResult
{
    public Guid Id { get; set; }
}