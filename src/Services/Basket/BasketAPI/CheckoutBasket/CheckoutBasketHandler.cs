using BuildingBlocks.Messaging.Events;
using Mapster;
using MassTransit;

namespace BasketAPI.CheckoutBasket;

public class CheckoutBasketHandler(IBasketRepository repository, IPublishEndpoint publishEndpoint) : ICommandHandler<CheckoutBasketCommand,CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        //Get existing basket with total price
        var basket = await repository.GetBasket(command.BasketCheckoutDto.UserName, cancellationToken);
        
        if (basket is null)
        {
            return new CheckoutBasketResult(false);
        }
        
        //Set total price on basket checkout event message
        var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;
        
        //Send checkout event message to RabbitMQ using MassTransit
        await publishEndpoint.Publish(eventMessage, cancellationToken);
        
        //Delete the basket
        await repository.DeleteBasket(command.BasketCheckoutDto.UserName, cancellationToken);

        return new CheckoutBasketResult(true);
    }
}