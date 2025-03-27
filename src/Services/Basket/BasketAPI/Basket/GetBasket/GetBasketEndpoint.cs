

namespace BasketAPI.Basket.GetBasket;

public class GetBasketEndpoint:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
       app.MapGet("/basket/{userName}", async (string userName,ISender sender) =>
       {
            var query=new GetBasketQuery{UserName = userName};
            
            var response=await sender.Send(query);

            return Results.Ok(response);
       })
       .WithName("Get Product By Id")
       .Produces<GetBasketResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Product by Id")
       .WithDescription("Get Product by Id");
    }
}