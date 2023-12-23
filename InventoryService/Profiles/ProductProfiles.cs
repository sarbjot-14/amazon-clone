using AutoMapper;
using InventoryService.Dto;
using InventoryService.Models;
using ProductService.Dtos;

namespace ProductService.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>();

            CreateMap<ProductCreateDto, Product>();

            CreateMap<OrderPublishedDto, Order>();

        }
    }

}