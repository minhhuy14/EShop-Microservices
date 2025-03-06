namespace CatalogAPI.Products.DeleteProduct;

internal class DeleteProductCommandHandler(IDocumentSession documentSession):ICommandHandler<DeleteProductCommand,DeleteProductResponse>
{
    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await documentSession.LoadAsync<Product>(request.Id, cancellationToken);
        if (product == null)
        {
            return new DeleteProductResponse
            {
                IsDeleted = false
            };
        }
        //Delete the product entity from the database
        documentSession.Delete(product);
        await documentSession.SaveChangesAsync(cancellationToken);

        return new DeleteProductResponse
        {
            IsDeleted = true
        };
        
    }
}
