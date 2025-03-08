namespace BasketAPI.Basket.StoreBasket;

public class StoreBasketCommandHandler(IBasketRepository repository):ICommandHandler<StoreBasketCommand,StoreBasketResponse>
{
    public async Task<StoreBasketResponse> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart=command.Cart;
        
        await repository.StoreBasket(cart,cancellationToken);

        return new StoreBasketResponse
        {
            UserName=cart.UserName
        };

    }
}