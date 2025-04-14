namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderCommand(Guid orderId) : ICommand<DeleteOrderResult>
{
    public Guid OrderId { get; set; }= orderId; 
}

public class DeleteOrderResult
{
    public bool IsSuccess { get; set; }
}