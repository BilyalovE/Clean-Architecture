using MediatR;

namespace Application.Order.Queries.GetById;

public class GetOrderByIdQuery : IRequest<OrderDto>
{
    public int Id { get; set; }
}