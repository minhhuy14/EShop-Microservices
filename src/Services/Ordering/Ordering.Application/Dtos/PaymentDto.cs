using Ordering.Domain.Enums;

namespace Ordering.Application.Dtos;

public class PaymentDto
{
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string Expiration { get; set; }
    public string Cvv { get; set; }
    public PaymentMethod Method { get; set; }
}