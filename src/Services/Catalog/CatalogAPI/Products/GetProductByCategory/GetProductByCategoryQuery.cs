namespace CatalogAPI.Products.GetProductByCategory;

public class GetProductByCategoryQuery: IQuery<GetProductByCategoryResponse>
{
    public string Category{ get; set; } = string.Empty;
}

public class GetProductByCategoryResponse
{
    public List<GetProductDto> Products { get; set; }
}