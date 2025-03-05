using CatalogAPI.DTOs;
using CatalogAPI.Exceptions;

namespace CatalogAPI.Products.GetProductById;

public class GetProductByIdQueryHandler(IDocumentSession session,ILogger<GetProductByIdQueryHandler> logger): IQueryHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByIdQueryHandler.Handle {@Query}", query);
        
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
        if (product == null)
        {
            throw new ProductNotFoundException(query.Id);
        }
        
        var response = new GetProductByIdResponse
        {
            Product = new GetProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageFile = product.ImageFile,
                Categories = product.Categories
            }
        };

        return response;
    }
}