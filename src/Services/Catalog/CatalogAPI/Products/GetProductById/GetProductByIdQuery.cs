using CatalogAPI.DTOs;

namespace CatalogAPI.Products.GetProductById;

public class GetProductByIdQuery: IQuery<GetProductByIdResponse>
{
    public string Id { get; set; } = string.Empty;
}

public class GetProductByIdResponse
{
    public GetProductDto Product { get; set; }
}