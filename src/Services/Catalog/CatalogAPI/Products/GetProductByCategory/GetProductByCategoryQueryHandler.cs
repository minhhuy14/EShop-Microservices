namespace CatalogAPI.Products.GetProductByCategory;

public class GetProductByCategoryQueryHandler(IDocumentSession session): IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResponse>
{
    public async Task<GetProductByCategoryResponse> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
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