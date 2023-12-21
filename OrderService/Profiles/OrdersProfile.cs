using AutoMapper;
using OrdersService.Dto;
using OrdersService.Models;

namespace OrdersService.Profiles{
    public class OrdersProfile : Profile{
        public OrdersProfile(){
            //Source -> Target
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
        }


    }
}