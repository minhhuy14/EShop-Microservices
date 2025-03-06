namespace CatalogAPI.Products.UpdateProduct;

public class UpdateProductCommand: ICommand<UpdateProductDto>
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<string> Categories { get; set; } = new();
    public string Description { get; set; } = string.Empty;

    public string ImageFile { get; set; } = string.Empty;

    public decimal Price { get; set; }
    
}