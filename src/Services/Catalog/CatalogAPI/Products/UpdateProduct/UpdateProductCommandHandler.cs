using CatalogAPI.Products.CreateProduct;

namespace CatalogAPI.Products.UpdateProduct;

internal class UpdateProductCommandHandler(IDocumentSession session):ICommandHandler<UpdateProductCommand,UpdateProductDto>
{

    public async Task<UpdateProductDto> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        //Business Logic to create a product
        //Create product entity from command object
        //Save the product entity to the database

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        if (product == null)
        {
            throw new ProductNotFoundException(command.Id);
        }
        
        product.Name = command.Name;
        product.Categories = command.Categories;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;
        
        //Save the product entity to the database
        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductDto
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
    }
}