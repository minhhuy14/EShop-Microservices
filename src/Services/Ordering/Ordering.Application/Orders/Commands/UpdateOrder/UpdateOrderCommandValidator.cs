using FluentValidation;

namespace Ordering.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandValidator:AbstractValidator<UpdateOrderCommand>
{
  public UpdateOrderCommandValidator()
  {
    RuleFor(x => x.Order.Id)
      .NotEmpty()
      .WithMessage("Id is required");
    
    RuleFor(x => x.Order.OrderName)
      .NotNull()
      .WithMessage("OrderName is required");
    
    RuleFor(x=>x.Order.CustomerId)
      .NotEmpty()
      .WithMessage("CustomerId is required");
    
  }
}