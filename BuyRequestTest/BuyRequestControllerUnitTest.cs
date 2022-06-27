using BuyRequest_Api.Controllers;
using BuyRequest_Application.Interface;
using BuyRequestDomain.DTO;
using BuyRequestDomain.Entity;
using Infrastructure.Entity;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BuyRequestTest
{
    public class BuyRequestControllerUnitTest
    {
        private readonly AutoMocker Mocker;

        public BuyRequestControllerUnitTest()
        {
            Mocker = new AutoMocker();
        }

        [Fact(DisplayName = "PostBuyRequest Test")]
        public async Task Post()
        {
            var buyReq = BuyRequestFaker.Generate();

            var buyReqService = Mocker.GetMock<IBuyRequestApplication>();
            buyReqService.Setup(X => X.AddBuyRequest(buyReq));

            var buyReqController = Mocker.CreateInstance<BuyRequestController>();

            await buyReqController.Post(buyReq);

            buyReqService.Verify(x => x.AddBuyRequest(It.IsAny<BuyRequestDTO>()), Times.Once());
        }

        [Fact(DisplayName = "GetAllBuyRequest Test")]
        public async Task GetAllBuyRequest()
        {
            var buyReqService = Mocker.GetMock<IBuyRequestApplication>();
            PageParameters pg = new PageParameters() { PageIndex = 1, PageSize = 100 };
            buyReqService.Setup(x => x.GetAllBuyRequests(pg));

            var buyReqController = Mocker.CreateInstance<BuyRequestController>();

            await buyReqController.GetAll(pg);

            buyReqService.Verify(x => x.GetAllBuyRequests(pg), Times.Once());
        }

        [Fact(DisplayName = "GetBuyRequestByClientId Test")]
        public async Task GetBuyRequestByClientId()
        {
            var buyRequest = new BuyRequest();

            var buyReqService = Mocker.GetMock<IBuyRequestApplication>();
            buyReqService.Setup(x => x.GetBuyRequestsByClient(buyRequest.Client));

            var buyReqController = Mocker.CreateInstance<BuyRequestController>();

            await buyReqController.GetByClient(buyRequest.Client);

            buyReqService.Verify(x => x.GetBuyRequestsByClient(buyRequest.Client), Times.Once());
        }

        [Fact(DisplayName = "UpdateBuyRequest Test")]
        public async Task UpdateBuyRequest()
        {
            var buyRequest = BuyRequestFaker.Generate();

            var buyReqService = Mocker.GetMock<IBuyRequestApplication>();
            buyReqService.Setup(x => x.GetBuyRequestsByClient(buyRequest.Client));
            buyReqService.Setup(X => X.UpdateBuyRequest(buyRequest));

            var buyReqController = Mocker.CreateInstance<BuyRequestController>();

            await buyReqController.Put(buyRequest);

            buyReqService.Verify(x => x.UpdateBuyRequest(It.IsAny<BuyRequestDTO>()), Times.Once());
        }

        [Fact(DisplayName = "DeleteBuyRequest Test")]
        public async Task DeleteBuyRequest()
        {
            var buyReq = BuyRequestFaker.Generate();

            var buyReqService = Mocker.GetMock<IBuyRequestApplication>();
            buyReqService.Setup(x => x.DeleteBuyRequest(buyReq.Id));

            var buyReqController = Mocker.CreateInstance<BuyRequestController>();

            await buyReqController.Delete(buyReq.Id);

            buyReqService.Verify(x => x.DeleteBuyRequest(buyReq.Id), Times.Once());
        }
    }
}