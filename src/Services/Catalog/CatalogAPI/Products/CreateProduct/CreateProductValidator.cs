namespace CatalogAPI.Products.CreateProduct;

public class CreateProductValidator:AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
        RuleFor(x => x.Categories)
            .NotEmpty()
            .WithMessage("Categories is required");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required");
        RuleFor(x => x.ImageFile)
            .NotEmpty()
            .WithMessage("ImageFile is required");
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");    }
}