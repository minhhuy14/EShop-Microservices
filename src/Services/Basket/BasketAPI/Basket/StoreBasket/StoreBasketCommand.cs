namespace BasketAPI.Basket.StoreBasket;

public class StoreBasketCommand:ICommand<StoreBasketResponse>
{
    public ShoppingCart Cart { get; set; }
}

public class StoreBasketResponse
{
    public string UserName { get; set; }
}