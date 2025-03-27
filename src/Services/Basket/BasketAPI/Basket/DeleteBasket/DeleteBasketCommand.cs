namespace BasketAPI.Basket.DeleteBasket;

public class DeleteBasketCommand:ICommand<DeleteBasketResponse>
{
    public string UserName { get; set; }
}

public class DeleteBasketResponse
{
    public bool IsSuccess { get; set; }
}
