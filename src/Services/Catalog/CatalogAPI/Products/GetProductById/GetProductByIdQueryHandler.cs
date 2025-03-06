using CatalogAPI.DTOs;
using CatalogAPI.Exceptions;

namespace CatalogAPI.Products.GetProductById;

public class GetProductByIdQueryHandler(IDocumentSession session): IQueryHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
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