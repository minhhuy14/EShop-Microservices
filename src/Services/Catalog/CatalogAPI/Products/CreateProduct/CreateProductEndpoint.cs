namespace CatalogAPI.Products.CreateProduct;

public record CreateProductRequest(string Name, List<string> Categories, string Description, string ImageFile, decimal Price);


public class CreateProductEndpoint:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request,ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateProductDto>( );
            
            return Results.Created($"/products/{response.Id}",response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductDto>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create product")
        .WithDescription("Create a new product");
    }
}