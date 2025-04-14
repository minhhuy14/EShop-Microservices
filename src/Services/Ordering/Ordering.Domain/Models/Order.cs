
namespace Ordering.Domain.Models;


public class Order: Aggregate<OrderId>
{
    private readonly List<OrderItem> _orderItems = new();
    
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
    
    public CustomerId CustomerId { get; set; }

    public OrderName OrderName { get; set; } = default!;
    
    public Address ShippingAddress { get; set; } = default!;
    
    public Address BillingAddress { get; set; } = default!;
    
    public Payment Payment { get; private set; } = default!;
    
    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public decimal TotalPrice
    {
        get => _orderItems.Sum(x => x.Price);
        
        private set {}
        
    }
    
    public static Order Create(OrderId orderId, CustomerId customerId, OrderName orderName, Address shippingAddress, Address billingAddress,Payment payment, OrderStatus status)
    {
        var order= new Order
        {
            Id = orderId,
            CustomerId = customerId,
            OrderName = orderName,
            ShippingAddress = shippingAddress,
            BillingAddress = billingAddress,
            Payment = payment,
            Status = status
        };
        
        order.AddDomainEvent(new OrderCreatedEvent(order));
        
        return order;
    }
    
    public void Update(OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment, OrderStatus status)
    {
        OrderName = orderName;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
        Payment = payment;
        Status = status;
        
        AddDomainEvent(new OrderUpdatedEvent(this));
    }
    
    public void Add(ProductId productId, int quantity, decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
        
        var orderItem = new OrderItem(Id, productId, quantity, price);
        _orderItems.Add(orderItem);
        
        AddDomainEvent(new OrderItemAddedEvent(this, orderItem));
    }
    
    public void Remove(OrderItemId orderItemId)
    {
        var orderItem = _orderItems.FirstOrDefault(x => x.Id == orderItemId);

        if (orderItem is not null)
        {
            _orderItems.Remove(orderItem);
        }
        
        AddDomainEvent(new OrderItemRemovedEvent(this, orderItem));
    }
}