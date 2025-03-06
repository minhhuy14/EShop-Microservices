namespace CatalogAPI.Products.GetProducts;

public class GetProductsEndpoint:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductsQuery request, ISender sender) =>
            { 
                var query = request.Adapt<GetProductsQuery>();
                var response = await sender.Send(query);
            
            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get products")
        .WithDescription("Get all products");
    }
}