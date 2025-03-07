namespace BasketAPI.Basket.DeleteBasket;

public class DeleteBasketHandler:ICommandHandler<DeleteBasketCommand,DeleteBasketResponse>
{
    public async Task<DeleteBasketResponse> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        //TODO: Delete Basket from DB and Cache
        //session.Delete<Basket>(command.Id);

        return new DeleteBasketResponse
        {
            IsSuccess = "true"
        };
    }
}
