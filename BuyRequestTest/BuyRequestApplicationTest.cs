using BuyRequest_Application.Applications;
using BuyRequest_Application.Interface;
using BuyRequest_Application.Service.Interface;
using BuyRequestDomain.DTO;
using BuyRequestDomain.Entity;
using Infrastructure.Entity;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BuyRequestTest
{
    public class BuyRequestApplicationTest
    {
        private readonly AutoMocker Mocker;

        public BuyRequestApplicationTest()
        {
            Mocker = new AutoMocker();
        }

        [Fact(DisplayName = "AddBuyRequest Test")]
        public async Task AddBuyRequest()
        {
            var buyReq = BuyRequestFaker.GenerateBuyRequest();

            var buyReqService = Mocker.GetMock<IBuyRequestService>();
            buyReqService.Setup(X => X.AddBuyRequest(buyReq));

            var buyApplication = Mocker.Get<IBuyRequestService>();

            await buyApplication.AddBuyRequest(buyReq);

            buyReqService.Verify(x => x.AddBuyRequest(It.IsAny<BuyRequest>()), Times.Once());
        }

        [Fact(DisplayName = "GetAllBuyRequest Test")]
        public async Task GetAllBuyRequest()
        {
            var buyReqService = Mocker.GetMock<IBuyRequestApplication>();
            PageParameters pg = new PageParameters() { PageIndex = 1, PageSize = 100 };
            buyReqService.Setup(x => x.GetAllBuyRequests(pg));

            var buyApplication = Mocker.Get<IBuyRequestApplication>();

            await buyApplication.GetAllBuyRequests(pg);

            buyReqService.Verify(x => x.GetAllBuyRequests(pg), Times.Once());
        }

        [Fact(DisplayName = "GetBuyRequestByClientId Test")]
        public async Task GetBuyRequestByClientId()
        {
            var buyRequest = new BuyRequest();

            var buyReqService = Mocker.GetMock<IBuyRequestApplication>();
            buyReqService.Setup(x => x.GetBuyRequestsByClient(buyRequest.Client));

            var buyReqApplication = Mocker.Get<IBuyRequestApplication>();

            await buyReqApplication.GetBuyRequestsByClient(buyRequest.Client);

            buyReqService.Verify(x => x.GetBuyRequestsByClient(buyRequest.Client), Times.Once());
        }

        [Fact(DisplayName = "UpdateBuyRequest Test")]
        public async Task UpdateBuyRequest()
        {
            var buyRequest = BuyRequestFaker.Generate();

            var buyReqService = Mocker.GetMock<IBuyRequestApplication>();
            buyReqService.Setup(x => x.GetBuyRequestsByClient(buyRequest.Client));
            buyReqService.Setup(X => X.UpdateBuyRequest(buyRequest));

            var buyApplication = Mocker.Get<IBuyRequestApplication>();

            await buyApplication.UpdateBuyRequest(buyRequest);

            buyReqService.Verify(x => x.UpdateBuyRequest(It.IsAny<BuyRequestDTO>()), Times.Once());
        }

        [Fact(DisplayName = "DeleteBuyRequest Test")]
        public async Task DeleteBuyRequest()
        {
            var buyReq = BuyRequestFaker.Generate();

            var buyReqService = Mocker.GetMock<IBuyRequestApplication>();
            buyReqService.Setup(x => x.DeleteBuyRequest(buyReq.Id));

            var buyApplication = Mocker.Get<IBuyRequestApplication>();

            await buyApplication.DeleteBuyRequest(buyReq.Id);

            buyReqService.Verify(x => x.DeleteBuyRequest(buyReq.Id), Times.Once());
        }
    }
}