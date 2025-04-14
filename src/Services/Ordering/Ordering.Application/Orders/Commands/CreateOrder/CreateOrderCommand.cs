using BuildingBlocks.CQRS;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : ICommand<CreateOrderResult>
{
    public OrderDto Order { get; set; }
}

public class CreateOrderResult
{
    public Guid Id { get; set; }
}