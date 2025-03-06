namespace CatalogAPI.Products.CreateProduct;

public class CreateProductDto
{
    public string Id { get; set; }
    
    public string Name { get; set; }

    public List<string> Categories { get; set; } = new();

    public string Description { get; set; } = null!;

    public string ImageFile { get; set; } = null!;
    
    public decimal Price { get; set; }
}