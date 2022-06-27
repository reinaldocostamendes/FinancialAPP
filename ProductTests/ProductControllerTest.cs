using BuyRequest_Application.Interface;
using BuyRequestDomain.Entity;
using Infrastructure.Entity;
using Moq;
using Moq.AutoMock;
using ProductAPI.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProductTests
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

        [Fact(DisplayName = "GetProductById Test")]
        public async Task GetProductById()
        {
            var product = new Product();

            var productApplication = Mocker.GetMock<IProductApplication>();
            productApplication.Setup(x => x.getProductById(product.Id));

            var buyReqController = Mocker.CreateInstance<ProductController>();

            await buyReqController.GetById(product.Id);

            productApplication.Verify(x => x.getProductById(product.Id), Times.Once());
        }

        [Fact(DisplayName = "UpdateProduct Test")]
        public async Task UpdateProduct()
        {
            var product = ProductFaker.Generate();
            var productDTO = ProductFaker.GenerateDTO();

            var buyReqService = Mocker.GetMock<IProductApplication>();
            buyReqService.Setup(x => x.getProductById(product.Id));
            buyReqService.Setup(X => X.UpdateProduct(product));

            var productController = Mocker.CreateInstance<ProductController>();

            await productController.Put(productDTO);

            buyReqService.Verify(x => x.UpdateProduct(It.IsAny<Product>()), Times.Once());
        }

        [Fact(DisplayName = "DeleteProduct Test")]
        public async Task DeleteBuyRequest()
        {
            var product = ProductFaker.Generate();

            var productApplication = Mocker.GetMock<IProductApplication>();
            productApplication.Setup(x => x.DeleteProduct(product.Id));

            var productController = Mocker.CreateInstance<ProductController>();

            await productController.Delete(product.Id);

            productApplication.Verify(x => x.DeleteProduct(product.Id), Times.Once());
        }
    }
}