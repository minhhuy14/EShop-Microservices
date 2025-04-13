using BuildingBlocks.CQRS;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands;

public class CreateOrderCommand : ICommand<CreateOrderResponse>
{
    public OrderDto Order { get; set; }
}

public class CreateOrderResponse
{
    Guid Id { get; set; }
}