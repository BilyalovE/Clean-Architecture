using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DomainServices.Interfaces;
using Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using MediatR;


namespace Application.Order.Queries.GetById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IOrderDomainService _orderDomainService;

    public GetOrderByIdQueryHandler(IMapper mapper, IDbContext dbContext,
        IOrderDomainService orderDomainService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _orderDomainService = orderDomainService;
    }
    
    
    public async Task<OrderDto> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
    {
        var order = await _dbContext.Orders
            .AsNoTracking()
            .Include(x => x.Items).ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == query.Id);

        if (order == null) throw new EntityNotFoundException();

        var dto = _mapper.Map<OrderDto>(order);
        dto.Total = _orderDomainService.GetTotal(order);
        return dto;
    }
}