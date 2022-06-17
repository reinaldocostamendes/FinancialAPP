using CashBookDomain.Entity;
using Infrastructure.Entity;
using Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBookData.Repository.Interface
{
    public interface ICashBookRepository : IRepositoryBase<CashBook>
    {
        Task AddCashBook(CashBook cashbook);

        Task<List<CashBook>> GetAllCashBook(PageParameters pageParameters);

        Task<CashBook> GetCashBookByOriginId(Guid Id);

        Task<CashBook> GetCashBookById(Guid id);

        Task PutCashBook(CashBook cashbook);
    }
}