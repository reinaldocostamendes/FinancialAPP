using AutoMapper;
using CashBook_Application.Application.Interface;
using CashBook_Application.Service.Interface;
using CashBookDomain.DTO;
using CashBookDomain.ViewModels;
using Infrastructure.Entity;
using Infrastructure.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashBook_Application.Application
{
    public class CashBookApplication : ICashBookApplication
    {
        private readonly ICashBookService _icashBookService;
        private readonly IMapper _imapper;

        public CashBookApplication(ICashBookService icashBookService, IMapper imapper)
        {
            _icashBookService = icashBookService;
            _imapper = imapper;
        }

        public async Task<CashBook> AddCashBook(CashBookDTO cashbook)
        {
            var cashBookInput = _imapper.Map<CashBook>(cashbook);

            if (!cashBookInput.IsValid())
            {
                var message = cashBookInput.
                   ValidationResult.Errors.
                   ConvertAll(x => x.ErrorMessage.ToString()).ToList();

                throw new Exception(ErrorList(message));
            }
            return await _icashBookService.AddCashBook(cashBookInput);
        }

        private String ErrorList(List<string> message)
        {
            var string_errors = "[ ";
            foreach (var error in message)
            {
                string_errors += " - " + error.ToString();
            }
            return string_errors + " ]";
        }

        public async Task<CashBookViewModel> GetAllCashBook(PageParameters pageParameters)
        {
            return await _icashBookService.GetAllCashBook(pageParameters);
        }

        public async Task<CashBook> GetCashBookOriginId(Guid Id)
        {
            return await _icashBookService.GetCashBookByOriginId(Id);
        }

        public async Task<CashBook> GetCashBookById(Guid id)
        {
            return await _icashBookService.GetCashBookById(id);
        }

        public async Task<CashBook> PutCashBook(CashBookDTO cashbook)
        {
            if (cashbook.Origin == CashBookOrigin.PURCHASEORDER || cashbook.Origin == CashBookOrigin.DOCUMENT)
            {
                throw new Exception("Not Possible to update integrated cashbook!");
            }

            var cashBookInput = _imapper.Map<CashBook>(cashbook);

            if (!cashBookInput.IsValid())
            {
                var message = cashBookInput.
                   ValidationResult.Errors.
                   ConvertAll(x => x.ErrorMessage.ToString()).ToList();

                throw new Exception(ErrorList(message));
            }
            return await _icashBookService.PutCashBook(cashBookInput);
        }
    }
}