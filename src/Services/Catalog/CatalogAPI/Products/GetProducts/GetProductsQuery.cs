namespace CatalogAPI.Products.GetProducts;

public class GetProductsQuery: IQuery<GetProductsResponse>
{
    
}

public class GetProductsResponse
{
    public List<GetProductsDto> Products { get; set; }
}