namespace BasketAPI.Basket.DeleteBasket;

public class DeleteBasketEndpoint:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName,ISender sender) =>
        {
            var command=new DeleteBasketCommand
            {
                UserName = userName
            };
            
            var response=await sender.Send(command);

            return Results.Ok(response);
        })
        .WithName("Delete Product")
        .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }
}