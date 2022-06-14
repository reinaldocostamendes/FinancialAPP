using CashBookDomain.Entity;
using CashBookDomain.ViewModels;
using Infrastructure.Entity;
using System;
using System.Threading.Tasks;

namespace CashBook_Application.Service.Interface
{
    public interface ICashBookService
    {
        Task<CashBook> AddCashBook(CashBook cashbook);

        Task<CashBookModel> GetAllCashBook(PageParameters pageParameters);

        Task<CashBook> GetCashBookByOriginId(Guid Id);

        Task<CashBook> GetCashBookById(Guid id);

        Task<CashBook> PutCashBook(CashBook cashbook);
    }
}