using BuildingBlocks.CQRS;

namespace CatalogAPI.Products.CreateProduct;

public class CreateProductCommand: ICommand<CreateProductDto>
{
    string Name { get; set; } = string.Empty;
    
    List<string> Categories { get; set; } = new();
    
    string Description { get; set; } = string.Empty;
    
    string ImageFile { get; set; } = string.Empty;
    
    decimal Price { get; set; }
    
}