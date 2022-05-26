using AutoMapper;
using BuyRequest_Application.Interface;
using BuyRequestDomain.DTO;
using Infrastructure.Entity;
using Moq;
using Moq.AutoMock;
using ProductAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.AutoFakers;
using Xunit;

namespace Tests
{
    public class ProductControllerTest
    {
        private readonly AutoMocker Mocker;

        public ProductControllerTest()
        {
            Mocker = new AutoMocker();
        }

        [Fact(DisplayName = "PostProduct Test")]
        public async Task Post()
        {
            var product = ProductFaker.Generate();
            var productDTO = ProductFaker.GenerateDTO();

            var buyReqService = Mocker.GetMock<IProductApplication>();
            buyReqService.Setup(X => X.AddProduct(product));

            var buyReqController = Mocker.CreateInstance<ProductController>();

            await buyReqController.Post(productDTO);

            buyReqService.Verify(x => x.AddProduct(It.IsAny<Product>()), Times.Once());
        }

        [Fact(DisplayName = "GetAllProducts Test")]
        public async Task GetAll()
        {
            var buyReqService = Mocker.GetMock<IProductApplication>();
            PageParameters pg = new PageParameters() { PageIndex = 1, PageSize = 100 };
            buyReqService.Setup(x => x.GetAllProducts());

            var buyReqController = Mocker.CreateInstance<ProductController>();

            await buyReqController.GetAll(pg);

            buyReqService.Verify(x => x.GetAllProducts(), Times.Once());
        }
    }
}