namespace BasketAPI.Basket.DeleteBasket;

public class DeleteBasketHandler(IBasketRepository repository):ICommandHandler<DeleteBasketCommand,DeleteBasketResponse>
{
    public async Task<DeleteBasketResponse> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {

        var existBasket = await repository.GetBasket(command.UserName,cancellationToken);
        
        if(existBasket==null)
        {
            throw new BasketNotFoundException(command.UserName);
        }
        
        await repository.DeleteBasket(command.UserName,cancellationToken);

        return new DeleteBasketResponse
        {
            IsSuccess =true
        };
    }
}
