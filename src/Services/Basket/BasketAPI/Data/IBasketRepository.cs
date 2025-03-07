namespace BasketAPI.Data;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken=default);
    
    Task<ShoppingCart> UpdateBasket(ShoppingCart basket, CancellationToken cancellationToken=default);
    
    Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken=default);
    
}