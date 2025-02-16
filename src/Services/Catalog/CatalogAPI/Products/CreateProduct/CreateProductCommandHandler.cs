using BuildingBlocks.CQRS;
using CatalogAPI.Models;

namespace CatalogAPI.Products.CreateProduct;

internal class CreateProductCommandHandler:ICommandHandler<CreateProductCommand,CreateProductDto>
{
    public async Task<CreateProductDto> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
       //Business Logic to create a product
       //Create product entity from command object
         //Save the product entity to the database

         var product = new Product
         {
             Name = command.Name,
             Categories = command.Categories,
             Description = command.Description,
             ImageFile = command.ImageFile,
             Price = command.Price
         };
            //Save the product entity to the database

            return new CreateProductDto(Guid.NewGuid());
    }
}