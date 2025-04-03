using Discount.Grpc;

namespace BasketAPI.Basket.StoreBasket;

public class StoreBasketCommandHandler(IBasketRepository repository,DiscountProtoService.DiscountProtoServiceClient discountProto):ICommandHandler<StoreBasketCommand,StoreBasketResponse>
{
    public async Task<StoreBasketResponse> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        //TODO: communicate with Discount.Grpc and calculate latest prices of product into shopping cart
        
        await DeductDiscount(command.Cart,cancellationToken);
        
        await repository.StoreBasket(command.Cart,cancellationToken);

        return new StoreBasketResponse
        {
            UserName=command.Cart.UserName
        };
    }
    
    private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        foreach (var item in cart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest
            {
                ProductName = item.ProductName
            }, cancellationToken:cancellationToken);
            
            item.Price -= coupon.Amount;
        }
    }
    
}