using AutoMapper;
using BuyRequestDomain.DTO;
using BuyRequestDomain.ViewModels;
using Infrastructure.Entity;
using System;

namespace BuyRequestDomain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BuyRequest, BuyRequestDTO>().ReverseMap();
            //  CreateMap<BuyRequestDTO, BuyRequest>().ForMember(op => op.Products, opt => opt.Ignore());
            /*  CreateMap<BuyRequestDTO, BuyRequest>().ForMember(op => op.Products, map =>
              map.MapFrom(src => $"{custumizedListOrderProduct(src.Products.ToList())}")).ReverseMap();*/

            CreateMap<BuyRequest, BuyRequestModel>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();

            /* CreateMap<ProductDTO, Product>()
                .ForMember(op => op.Total, map => map.MapFrom(src => $"{src.Quantity}*{src.Value}")).ReverseMap();*/
        }
    }
}