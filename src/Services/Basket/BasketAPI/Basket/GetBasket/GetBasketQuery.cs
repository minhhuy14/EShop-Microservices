namespace BasketAPI.Basket.GetBasket;

public class GetBasketQuery:IQuery<GetBasketResponse>
{
    public string UserName { get; set; }
    
    
}

public class GetBasketResponse
{
    public ShoppingCart Cart { get; set; }

}