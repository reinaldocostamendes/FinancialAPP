using AutoMapper;
using BuyRequest_Application.Interface;
using BuyRequestDomain.DTO;
using BuyRequestDomain.Entity;
using BuyRequestDomain.Mapping;
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
    public class BuyRequestRabbitMQTests
    {
        private readonly AutoMocker Mocker;
        private static IMapper _mapper;

        public BuyRequestRabbitMQTests()
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

        [Fact(DisplayName = "BuyRequestSendCashBook Test")]
        public void SendCasBook()
        {
            var buyReqDTO = BuyRequestFaker.Generate();

            var buyRequest = _mapper.Map<BuyRequest>(buyReqDTO);
            Assert.True((buyReqDTO.Code == buyRequest.Code && buyReqDTO.Date == buyRequest.Date));
        }
    }
}