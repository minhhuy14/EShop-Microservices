namespace BasketAPI.Basket.StoreBasket;

public class StoreBasketCommandHandler:ICommandHandler<StoreBasketCommand,StoreBasketResponse>
{
    public async Task<StoreBasketResponse> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        // ShoppingCart cart=command.Cart;
        
        //TODO: Store Basket in DB
        //TODO: Update cache

        return new StoreBasketResponse
        {
            UserName="My user name"
        };

    }
}