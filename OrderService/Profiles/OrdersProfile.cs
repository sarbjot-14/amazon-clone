using AutoMapper;
using OrdersService.Dto;
using OrdersService.Models;

namespace OrdersService.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            //Source -> Target 
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderReadDto, OrderPublishedDto>();
            CreateMap<Order, OrderPublishedDto>();
            CreateMap<List<OrderCreateDto>, List<Order>>();

        }


    }
}