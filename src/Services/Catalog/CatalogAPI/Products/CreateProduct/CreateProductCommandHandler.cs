namespace CatalogAPI.Products.CreateProduct;

internal class CreateProductCommandHandler(IDocumentSession session):ICommandHandler<CreateProductCommand,CreateProductDto>
{
    public async Task<CreateProductDto> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
       //Business Logic to create a product
       //Create product entity from command object
         //Save the product entity to the database

         var product = new Product
         {
             Id=Guid.NewGuid().ToString(),
             Name = command.Name,
             Categories = command.Categories,
             Description = command.Description,
             ImageFile = command.ImageFile,
             Price = command.Price
         };
            //Save the product entity to the database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductDto
            {
                Id = product.Id
            };
    }
}