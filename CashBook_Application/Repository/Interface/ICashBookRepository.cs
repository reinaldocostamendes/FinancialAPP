using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CashBook_Application.Repository.Interface
{
    public interface ICashBookRepository
    {
        Task AddCashBook(CashBook cashbook);

        Task<List<CashBook>> GetAllCashBook(PageParameters pageParameters);

        Task<CashBook> GetCashBookByOriginId(Guid Id);

        Task<CashBook> GetCashBookById(Guid id);

        Task PutCashBook(CashBook cashbook);
    }
}