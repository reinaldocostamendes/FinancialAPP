﻿using CashBook_Application.Context;
using CashBook_Application.Repository.Interface;
using Infrastructure.Entity;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashBook_Application.Repository
{
    public class CashBookRepository : RepositoryBase<CashBook>, ICashBookRepository
    {
        private readonly CashBookContext _context;

        public CashBookRepository(CashBookContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddCashBook(CashBook cashbook)
        {
            await Post(cashbook);
        }

        public async Task<List<CashBook>> GetAllCashBook(PageParameters pageParameters)
        {
            return await GetAll(pageParameters);
        }

        public async Task<CashBook> GetCashBookById(Guid id)
        {
            return await GetById(id);
        }

        public async Task<CashBook> GetCashBookByOriginId(Guid Id)
        {
            return await _context.CashBooks.Where(c => c.OriginId == Id).FirstOrDefaultAsync();
        }

        public async Task PutCashBook(CashBook cashbook)
        {
            await Put(cashbook);
        }
    }
}