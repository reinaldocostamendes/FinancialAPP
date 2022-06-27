using CashBook_Api.Controllers;
using CashBook_Application.Application;
using CashBook_Application.Application.Interface;
using CashBookDomain.DTO;
using CashBookDomain.Entity;
using Infrastructure.Entity;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CashBookUnitTests
{
    public class CashBookApplicationUnitTests
    {
        private readonly AutoMocker Mocker;

        public CashBookApplicationUnitTests()
        {
            Mocker = new AutoMocker();
        }

        [Fact(DisplayName = "AddCashBook Test")]
        public async Task AddCashBook()
        {
            var cashBook = CashBooktFaker.GenerateBCashBookDTO();

            var cashBookService = Mocker.GetMock<ICashBookApplication>();
            cashBookService.Setup(X => X.AddCashBook(cashBook));

            var cashBookApplication = Mocker.Get<ICashBookApplication>();

            await cashBookApplication.AddCashBook(cashBook);

            cashBookService.Verify(x => x.AddCashBook(It.IsAny<CashBookDTO>()), Times.Once());
        }

        [Fact(DisplayName = "GetAllCashBook Test")]
        public async Task GetAllBankRequest()
        {
            var cashBookService = Mocker.GetMock<ICashBookApplication>();
            PageParameters pg = new PageParameters() { PageIndex = 1, PageSize = 100 };
            cashBookService.Setup(x => x.GetAllCashBook(pg));

            var cashBookApplication = Mocker.Get<ICashBookApplication>();

            await cashBookApplication.GetAllCashBook(pg);

            cashBookService.Verify(x => x.GetAllCashBook(pg), Times.Once());
        }

        [Fact(DisplayName = "GetCashBookById Test")]
        public async Task GetByIdBankRequest()
        {
            var cashBook = new CashBook();

            var cashBookService = Mocker.GetMock<ICashBookApplication>();
            cashBookService.Setup(x => x.GetCashBookById(cashBook.Id));

            var cashBookApplication = Mocker.Get<ICashBookApplication>();

            await cashBookApplication.GetCashBookById(cashBook.Id);

            cashBookService.Verify(x => x.GetCashBookById(cashBook.Id), Times.Once());
        }

        [Fact(DisplayName = "GetCashBookByOriginId Test")]
        public async Task GetCashBookByOriginId()
        {
            var id = Guid.NewGuid();

            var cashBook = new CashBook();

            var cashBookService = Mocker.GetMock<ICashBookApplication>();
            cashBookService.Setup(x => x.GetCashBookOriginId(id));

            var cashBookApplication = Mocker.Get<ICashBookApplication>();

            await cashBookApplication.GetCashBookOriginId(id);

            cashBookService.Verify(x => x.GetCashBookOriginId(id), Times.Once());
        }

        [Fact(DisplayName = "UpdateCashBook Test")]
        public async Task UpdateCashBook()
        {
            var cashBook = CashBooktFaker.GenerateCashBook();

            var cashBookService = Mocker.GetMock<ICashBookApplication>();
            cashBookService.Setup(x => x.GetCashBookById(cashBook.Id)).ReturnsAsync(cashBook);
            cashBookService.Setup(X => X.PutCashBook(new CashBookDTO()));

            var cashBookApplication = Mocker.Get<ICashBookApplication>();

            await cashBookApplication.PutCashBook(new CashBookDTO());

            cashBookService.Verify(x => x.PutCashBook(It.IsAny<CashBookDTO>()), Times.Once());
        }
    }
}