namespace BasketAPI.Basket.DeleteBasket;

public class DeleteBasketCommand:ICommand<DeleteBasketResponse>
{
    public string UserName { get; set; }
}

public class DeleteBasketResponse
{
    public string IsSuccess { get; set; }
}
