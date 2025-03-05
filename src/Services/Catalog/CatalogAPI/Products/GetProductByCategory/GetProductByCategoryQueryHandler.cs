namespace CatalogAPI.Products.GetProductByCategory;

public class GetProductByCategoryQueryHandler(IDocumentSession session,ILogger<GetProductByCategoryQueryHandler> logger): IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResponse>
{
    public async Task<GetProductByCategoryResponse> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByCategoryQueryHandler.Handle {@Query}", query);
        
        var product = await session.Query<Product>()
            .Where(p => p.Categories.Contains(query.Category))
            .ToListAsync(cancellationToken);
        if (product == null)
        {
            throw new ProductNotFoundException(query.Category);
        }
        
        var response = new GetProductByCategoryResponse
        {
            Products = product.Select(p => new GetProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ImageFile = p.ImageFile,
                Categories = p.Categories
            }).ToList()
        };

        return response;
    }
}