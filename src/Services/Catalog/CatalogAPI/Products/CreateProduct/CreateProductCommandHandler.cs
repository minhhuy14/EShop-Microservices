using BuildingBlocks.CQRS;

namespace CatalogAPI.Products.CreateProduct;

internal class CreateProductCommandHandler:ICommandHandler<CreateProductCommand,CreateProductDto>
{
    public Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
       //Business Logic to create a product
         return Task.FromResult(new CreateProductDto());
    }
}