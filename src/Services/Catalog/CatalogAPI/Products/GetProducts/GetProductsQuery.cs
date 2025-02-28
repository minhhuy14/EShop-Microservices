using CatalogAPI.DTOs;

namespace CatalogAPI.Products.GetProducts;

public class GetProductsQuery: IQuery<GetProductsResponse>
{
    
}

public class GetProductsResponse
{
    public List<GetProductDto> Products { get; set; }
}