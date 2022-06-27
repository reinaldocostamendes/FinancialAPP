using AutoMapper;
using BuyRequest_Application.Interface;
using BuyRequestDomain.Entity;
using BuyRequestDomain.Mapping;
using Infrastructure.Entity;
using Moq;
using Moq.AutoMock;
using ProductAPI.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProductTests
{
    public class ProductMapperTest
    {
        private readonly AutoMocker Mocker;
        private static IMapper _mapper;

        public ProductMapperTest()
        {
            Mocker = new AutoMocker();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact(DisplayName = "MapProduct Test")]
        public async Task Map()
        {
            var productDTO = ProductFaker.GenerateDTO();
            Product product = _mapper.Map<Product>(productDTO);
            Assert.True(product.Total == productDTO.Total &&
                product.Value == productDTO.Value &&
                productDTO.Quantity == product.Quantity);
        }
    }
}