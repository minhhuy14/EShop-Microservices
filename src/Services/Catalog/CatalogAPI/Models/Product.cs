namespace CatalogAPI.Models;

public class Product
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public List<string> Categories { get; set; } = new();

    public string Description { get; set; } = null!;

    public string ImageFile { get; set; } = null!;
    
    public decimal Price { get; set; }

}