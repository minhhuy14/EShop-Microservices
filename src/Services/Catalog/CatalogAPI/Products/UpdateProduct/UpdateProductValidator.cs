using NetTopologySuite.Algorithm;

namespace CatalogAPI.Products.UpdateProduct;

public class UpdateProductValidator:AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(command=>command.Id)
            .NotEmpty()
            .WithMessage("Product Id is required");
        RuleFor(command=>command.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .Length(2,150)
            .WithMessage("Name must be between 2 and 150 characters");
        RuleFor(command=>command.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
}