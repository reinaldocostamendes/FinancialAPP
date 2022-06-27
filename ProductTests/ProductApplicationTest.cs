using BuyRequest_Application.Applications;
using BuyRequest_Application.Interface;
using BuyRequestDomain.Entity;
using Infrastructure.Entity;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProductTests
{
    public class ProductApplicationTest
    {
        private readonly AutoMocker Mocker;

        public ProductApplicationTest()
        {
            Mocker = new AutoMocker();
        }

        [Fact(DisplayName = "PostProduct Test")]
        public async Task Post()
        {
            var product = ProductFaker.Generate();
            var productDTO = ProductFaker.Generate();

            var productService = Mocker.GetMock<IProductApplication>();
            productService.Setup(X => X.AddProduct(product));

            var productApplication = Mocker.Get<IProductApplication>();

            await productApplication.AddProduct(productDTO);

            productService.Verify(x => x.AddProduct(It.IsAny<Product>()), Times.Once());
        }

        [Fact(DisplayName = "GetAllProducts Test")]
        public async Task GetAll()
        {
            var productService = Mocker.GetMock<IProductApplication>();
            PageParameters pg = new PageParameters() { PageIndex = 1, PageSize = 100 };
            productService.Setup(x => x.GetAllProducts());

            var productApplication = Mocker.Get<IProductApplication>();

            await productApplication.GetAllProducts();

            productService.Verify(x => x.GetAllProducts(), Times.Once());
        }

        [Fact(DisplayName = "GetProductById Test")]
        public async Task GetProductById()
        {
            var product = new Product();

            var productService = Mocker.GetMock<IProductApplication>();
            productService.Setup(x => x.getProductById(product.Id));

            var productApplication = Mocker.Get<IProductApplication>();

            await productApplication.getProductById(product.Id);

            productService.Verify(x => x.getProductById(product.Id), Times.Once());
        }

        [Fact(DisplayName = "UpdateProduct Test")]
        public async Task UpdateProduct()
        {
            var product = ProductFaker.Generate();
            var productDTO = ProductFaker.Generate();

            var productService = Mocker.GetMock<IProductApplication>();
            productService.Setup(x => x.getProductById(product.Id));
            productService.Setup(X => X.UpdateProduct(product));

            var productApplication = Mocker.Get<IProductApplication>();

            await productApplication.UpdateProduct(productDTO);

            productService.Verify(x => x.UpdateProduct(It.IsAny<Product>()), Times.Once());
        }

        [Fact(DisplayName = "DeleteProduct Test")]
        public async Task DeleteBuyRequest()
        {
            var product = ProductFaker.Generate();

            var productService = Mocker.GetMock<IProductApplication>();
            productService.Setup(x => x.DeleteProduct(product.Id));

            var productApplication = Mocker.Get<IProductApplication>();

            await productApplication.DeleteProduct(product.Id);

            productService.Verify(x => x.DeleteProduct(product.Id), Times.Once());
        }
    }
}