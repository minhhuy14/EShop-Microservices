namespace CatalogAPI.Products.GetProductById;

public class GetProductByQueryEndpoint:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (string id, ISender sender) =>
            {
                var query = new GetProductByIdQuery { Id = id };
                var response = await sender.Send(query);

                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get product by id")
            .WithDescription("Get a product by id");
    }
}