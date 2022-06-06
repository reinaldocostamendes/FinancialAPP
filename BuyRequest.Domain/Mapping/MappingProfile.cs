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

            CreateMap<BuyRequest, BuyRequestModel>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}