using AutoMapper;
using Infrastructure.Interfaces.DataAccess;
using MediatR;

namespace Application.Order.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IDbContext _dbContext;
    
    public CreateOrderCommandHandler(IMapper mapper, IDbContext dbContext, IMediator mediator)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Domain.Entities.Order>(command.Dto);
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
        return order.Id;
    }
}