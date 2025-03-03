using System.Data;

namespace CatalogAPI.Products.DeleteProduct;

public class DeleteProductValidator:AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ProductId is required");
    }
}