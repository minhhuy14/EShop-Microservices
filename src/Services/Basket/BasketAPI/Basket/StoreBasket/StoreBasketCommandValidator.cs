namespace BasketAPI.Basket.StoreBasket;

public class StoreBasketCommandValidator:AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
       RuleFor(x=>x.Cart)
           .NotNull()
           .WithMessage("Cart cannot be null");
       RuleFor(x=>x.Cart.UserName)
           .NotNull()
           .NotEmpty()
           .WithMessage("UserName cannot be null or empty");
    }
    
}