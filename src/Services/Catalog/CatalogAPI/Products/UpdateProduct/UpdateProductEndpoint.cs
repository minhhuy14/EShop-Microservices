using CatalogAPI.Products.CreateProduct;

namespace CatalogAPI.Products.UpdateProduct;

public record UpdateProductRequest(string Id,string Name, List<string> Categories, string Description, string ImageFile, decimal Price);

public record UpdateProductResponse(Guid Id);

public class UpdateProductEndpoint:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request,ISender sender) =>
        {
            var command = request.Adapt<UpdateProductCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<UpdateProductDto>( );

            return Results.Ok(response);
        })
        .WithName("UpdateProduct")
        .Produces<UpdateProductDto>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update product")
        .WithDescription("Update a new product");
    }
}