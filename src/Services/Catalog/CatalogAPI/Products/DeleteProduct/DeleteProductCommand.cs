namespace CatalogAPI.Products.DeleteProduct;

public class DeleteProductCommand : ICommand<DeleteProductResponse>
{
    public string Id { get; set;} 
}


public class DeleteProductResponse
{
    public bool IsDeleted { get; set; }
}