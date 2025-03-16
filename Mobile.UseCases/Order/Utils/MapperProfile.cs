using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using AutoMapper;
using Domain.Entities;



namespace Application;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Domain.Entities.Order, OrderDto>();
        CreateMap<CreateOrderDto, Domain.Entities.Order>();
        CreateMap<OrderItemDto, OrderItem>();
    }
    
}