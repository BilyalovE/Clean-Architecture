using MediatR;

namespace Application.Order.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<int>
{
    public CreateOrderDto Dto { get; set; }
}