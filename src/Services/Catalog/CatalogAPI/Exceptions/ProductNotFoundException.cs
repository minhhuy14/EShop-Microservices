using BuildingBlocks.Exceptions;

namespace CatalogAPI.Exceptions;

public class ProductNotFoundException:NotFoundException
{
    public ProductNotFoundException(string Id):base("Product", Id)
    {
        
    }
}