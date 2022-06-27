using CashBook_Application.Application;
using CashBook_Application.Application.Interface;
using CashBookDomain.DTO;
using Moq;
using Moq.AutoMock;
using Producer;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestsRabbitMQ
{
    public class SendMessageMQUnitTest
    {
        private readonly Mock<IMessageProducer> _messageProducer;

        private readonly AutoMocker Mocker;

        public SendMessageMQUnitTest()
        {
            _messageProducer = new Mock<IMessageProducer>();
            Mocker = new AutoMocker();
        }

        [Fact(DisplayName = "SendCashBook Test")]
        public async Task SendCashBookTestTest()
        {
            // Arrange

            var cashBookDto = CashBooktFaker.GenerateBCashBookDTO();

            var icashBookApplication = Mocker.GetMock<ICashBookApplication>();
            icashBookApplication.Setup(X => X.AddCashBook(cashBookDto));

            _messageProducer.Setup(X => X.SendMessage(cashBookDto));

            var application = Mocker.Get<IMessageProducer>();

            // Act

            var result = Task.Run(() => { application.SendMessage(cashBookDto); });

            // Assert

            await result.ShouldNotThrowAsync();
        }
    }
}