using Mapster;

namespace BasketAPI.Basket.StoreBasket;

public class StoreBasketEndpoint:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/basket", async (StoreBasketCommand request, ISender sender) =>
            {
                var result=await sender.Send(request);
                
                var response = result.Adapt<StoreBasketResponse>();
                
                return Results.Created($"/basket/{response.UserName}", response);
            }
        )
        .WithName("Create Product")
        .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}