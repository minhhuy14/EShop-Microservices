namespace Ordering.Application.Extensions;

public static class OrderExtensions
{
    public static IEnumerable<OrderDto> ToOrderDtosList(this IEnumerable<Order> orders)
    {
       return orders.Select(order => new OrderDto
        {
            Id = order.Id.Value,
            Name = order.OrderName.Value,
            CustomerId = order.CustomerId.Value,
            ShippingAddress = new AddressDto
            {
                FirstName = order.ShippingAddress.FirstName,
                LastName = order.ShippingAddress.LastName,
                EmailAddress = order.ShippingAddress.Email,
                AddressLine = order.ShippingAddress.AddressLine,
                Country = order.ShippingAddress.Country,
                State = order.ShippingAddress.State,
                ZipCode = order.ShippingAddress.ZipCode
            },
            BillingAddress = new AddressDto
            {
                FirstName = order.BillingAddress.FirstName,
                LastName = order.BillingAddress.LastName,
                EmailAddress = order.BillingAddress.Email,
                AddressLine = order.BillingAddress.AddressLine,
                Country = order.BillingAddress.Country,
                State = order.BillingAddress.State,
                ZipCode = order.BillingAddress.ZipCode
            },
            Payment = new PaymentDto
            {
                CardName = order.Payment.CardName,
                CardNumber = order.Payment.CardNumber,
                Expiration = order.Payment.Expiration,
                Cvv = order.Payment.Cvv,
                Method = order.Payment.Method
            },
            OrderItems = order.OrderItems.Select(
                oi => new OrderItemDto
                {
                    OrderId = oi.OrderId.Value,
                    ProductId = oi.ProductId.Value,
                    Quantity = oi.Quantity,
                    Price = oi.Price
                }
            ).ToList(),
            Status = order.Status
            
        });
    }
}