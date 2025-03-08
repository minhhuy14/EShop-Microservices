using BasketAPI.Data;

namespace BasketAPI.Basket.GetBasket;

public class GetBasketQueryHandler(IBasketRepository repository):IQueryHandler<GetBasketQuery, GetBasketResponse>
{
    public async Task<GetBasketResponse> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
      
       var basket = await repository.GetBasket(query.UserName, cancellationToken);

       return new GetBasketResponse
       {
           Cart=new ShoppingCart(basket.UserName)
           {
               Items=basket.Items
           }
       };
    }
}