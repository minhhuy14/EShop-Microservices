using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.API.Endpoints;

// Accept a CreateOrderRequest
// Map to a CreateOrderCommand
// Use MediatR to send the command to the corresponding handler
// Returns a success or failure response

public record CreateOrderRequest(OrderDto Order);

public record CreateOrderResponse(Guid Id);

public class CreateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
                {
                    var command = request.Adapt<CreateOrderCommand>();

                    var result = await sender.Send(command);

                    var response = result.Adapt<CreateOrderResponse>();

                    return Results.Created($"/orders/{response.Id}", response);
                }
            )
            .WithName("CreateOrder")
            .Produces<CreateOrderResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Order")
            .WithDescription("Creates a new order");
    }
}