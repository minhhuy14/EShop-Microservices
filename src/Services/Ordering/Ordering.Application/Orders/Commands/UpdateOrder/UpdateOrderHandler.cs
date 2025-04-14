namespace Ordering.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateOrderCommand, UpdateOrderResponse>
{
    public async Task<UpdateOrderResponse> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        //Update order entity from command object
        //Save to tse
        //Return result

        var orderId=OrderId.Of(command.Order.Id);
        var order = await dbContext.Orders.FindAsync([orderId], cancellationToken);
        
        if (order == null)
        {
            throw new OrderNotFoundException(command.Order.Id);
        }
        
        UpdateOrderWithNewValues(order, command.Order);
        
        dbContext.Orders.Update(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        throw new NotImplementedException();
        
        

    }

    private void UpdateOrderWithNewValues(Order order, OrderDto orderDto)
    {
        var updatedShippingAddress = Address.Of(orderDto.ShippingAddress.FirstName,
            orderDto.ShippingAddress.LastName, orderDto.ShippingAddress.EmailAddress, orderDto.ShippingAddress.AddressLine,
            orderDto.ShippingAddress.Country, orderDto.ShippingAddress.State, orderDto.ShippingAddress.ZipCode);
        
        var updatedBillingAddress = Address.Of(orderDto.BillingAddress.FirstName,orderDto.BillingAddress.LastName,
            orderDto.BillingAddress.EmailAddress, orderDto.BillingAddress.AddressLine, orderDto.BillingAddress.Country,
            orderDto.BillingAddress.State, orderDto.BillingAddress.ZipCode);
        
        var updatedPayment = Payment.Of(orderDto.Payment.CardName,orderDto.Payment.CardNumber,orderDto.Payment.Expiration,orderDto.Payment.Cvv,orderDto.Payment.Method);
        
        order.Update(OrderName.Of(orderDto.Name),updatedShippingAddress, updatedBillingAddress, updatedPayment, orderDto.Status);
        
    }


}