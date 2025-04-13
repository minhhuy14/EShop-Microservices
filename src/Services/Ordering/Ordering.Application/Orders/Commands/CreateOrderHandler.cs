using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Commands;

public class CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResponse>
{
    public Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        //Create order entity from command object
        //Save to the database
        //Return result
        
        throw new NotImplementedException();
    }
}