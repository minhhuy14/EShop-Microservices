namespace BasketAPI.Basket.GetBasket;

public class GetBasketQueryHandler:IQueryHandler<GetBasketQuery, GetBasketResponse>
{
    public async Task<GetBasketResponse> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
       //TODO: Get Basket from DB
       //var basket = await _repository.GetBasket(query.UserName);

       return new GetBasketResponse
       {
           Cart=new ShoppingCart("test-user")
       };
    }
}