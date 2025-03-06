using CatalogAPI.DTOs;

namespace CatalogAPI.Products.GetProducts;

public class GetProductsQuery: IQuery<GetProductsResponse>
{
    public int? PageNumber { get; set; } = 1;
    
    public int? PageSize { get; set; } = 10;
}

public class GetProductsResponse
{
    public List<GetProductDto> Products { get; set; }
}