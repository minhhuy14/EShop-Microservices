namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteOrderCommand,DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        //Delete order from command object
        //Save to db
        //Return result
        
        var orderId=OrderId.Of(command.OrderId);
        var order = await dbContext.Orders.FindAsync([orderId], cancellationToken);
        
        if (order == null)
        {
            throw new OrderNotFoundException(command.OrderId);
        }
        
        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new DeleteOrderResult
        {
           IsSuccess = true
        };
        
    }
}