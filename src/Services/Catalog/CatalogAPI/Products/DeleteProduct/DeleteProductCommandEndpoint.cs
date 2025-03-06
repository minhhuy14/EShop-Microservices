namespace CatalogAPI.Products.DeleteProduct;

public class DeleteProductCommandEndpoint:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (string id, ISender sender) =>
            {
                var command = new DeleteProductCommand { Id = id };
                
                var response= await sender.Send(command);

                return Results.Ok(response);
            })
            .WithName("DeleteProduct")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete product")
            .WithDescription("Delete a product");
    }
}