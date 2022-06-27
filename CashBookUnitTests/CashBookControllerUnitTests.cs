using CashBook_Api.Controllers;
using CashBook_Application.Application.Interface;
using CashBookDomain.DTO;
using CashBookDomain.Entity;
using Infrastructure.Entity;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CashBookUnitTests
{
    public class CashBookControllerUnitTests
    {
        private readonly AutoMocker Mocker;

        public CashBookControllerUnitTests()
        {
            Mocker = new AutoMocker();
        }

        [Fact(DisplayName = "PostCashBook Test")]
        public async Task PostBankRequest()
        {
            var cashBook = CashBooktFaker.GenerateBCashBookDTO();

            var cashBookService = Mocker.GetMock<ICashBookApplication>();
            cashBookService.Setup(X => X.AddCashBook(cashBook));

            var cashBookController = Mocker.CreateInstance<CashBookController>();

            await cashBookController.Post(cashBook);

            cashBookService.Verify(x => x.AddCashBook(It.IsAny<CashBookDTO>()), Times.Once());
        }

        [Fact(DisplayName = "GetAllCashBook Test")]
        public async Task GetAllBankRequest()
        {
            var cashBookService = Mocker.GetMock<ICashBookApplication>();
            PageParameters pg = new PageParameters() { PageIndex = 1, PageSize = 100 };
            cashBookService.Setup(x => x.GetAllCashBook(pg));

            var cashBookController = Mocker.CreateInstance<CashBookController>();

            await cashBookController.GetAll(pg);

            cashBookService.Verify(x => x.GetAllCashBook(pg), Times.Once());
        }

        [Fact(DisplayName = "GetCashBookById Test")]
        public async Task GetByIdBankRequest()
        {
            var cashBook = new CashBook();

            var cashBookService = Mocker.GetMock<ICashBookApplication>();
            cashBookService.Setup(x => x.GetCashBookById(cashBook.Id));

            var cashBookController = Mocker.CreateInstance<CashBookController>();

            await cashBookController.GetById(cashBook.Id);

            cashBookService.Verify(x => x.GetCashBookById(cashBook.Id), Times.Once());
        }

        [Fact(DisplayName = "GetCashBookByOriginId Test")]
        public async Task GetByOriginIdBankRequest()
        {
            var id = Guid.NewGuid();

            var cashBook = new CashBook();

            var cashBookService = Mocker.GetMock<ICashBookApplication>();
            cashBookService.Setup(x => x.GetCashBookOriginId(id));

            var bankReqController = Mocker.CreateInstance<CashBookController>();

            await bankReqController.GetByOrigintId(id);

            cashBookService.Verify(x => x.GetCashBookOriginId(id), Times.Once());
        }

        [Fact(DisplayName = "UpdateCashBook Test")]
        public async Task UpdateBankRequest()
        {
            var cashBook = CashBooktFaker.GenerateCashBook();

            var cashBookService = Mocker.GetMock<ICashBookApplication>();
            cashBookService.Setup(x => x.GetCashBookById(cashBook.Id)).ReturnsAsync(cashBook);
            cashBookService.Setup(X => X.PutCashBook(new CashBookDTO()));

            var cashBookController = Mocker.CreateInstance<CashBookController>();

            await cashBookController.Put(new CashBookDTO());

            cashBookService.Verify(x => x.PutCashBook(It.IsAny<CashBookDTO>()), Times.Once());
        }
    }
}