namespace BasketAPI.CheckoutBasket;

public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>, ICommand<Unit>;

public record CheckoutBasketResult(bool IsSuccess);

