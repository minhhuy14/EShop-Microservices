namespace CatalogAPI.Products.GetProducts;

internal class GetProductsQueryHandler(IDocumentSession session,ILogger<GetProductsQueryHandler> logger): IQueryHandler<GetProductsQuery, GetProductsResponse>
{
    public async Task<GetProductsResponse> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler.Handle {@Query}", query);
        
        var products = await session.Query<Product>().ToListAsync(cancellationToken);
        
        var listProducts = products.Select(p => new GetProductsDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            ImageFile = p.ImageFile,
            Categories = p.Categories
        }).ToList();
        
        var response = new GetProductsResponse
        {
            Products = listProducts
        };

        return response;
    }
}