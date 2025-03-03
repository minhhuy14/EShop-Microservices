namespace CatalogAPI.Products.DeleteProduct;

internal class DeleteProductCommandHandler(IDocumentSession documentSession,ILogger<DeleteProductCommandHandler> logger):ICommandHandler<DeleteProductCommand,DeleteProductResponse>
{
    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteProductCommandHandler.Handle {@Request}", request);
        
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
