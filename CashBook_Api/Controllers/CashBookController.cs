using CashBook_Api.Contracts;
using CashBook_Application.Application.Interface;
using CashBookDomain.DTO;
using CashBookDomain.ViewModels;
using Infrastructure.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CashBook_Api.Controllers
{
    [Route("api/CashBooks")]
    [ApiController]
    public class CashBookController : ControllerBase
    {
        private readonly ICashBookApplication _icashBookApplication;

        public CashBookController(ICashBookApplication icashBookApplication)
        {
            _icashBookApplication = icashBookApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CashBookDTO cashbook)
        {
            CashBook inserted = null;
            try
            {
                inserted = await _icashBookApplication.AddCashBook(cashbook);
            }
            catch (Exception ex)
            {
                return BadRequest(new CashBookErrorMessage("" + (int)HttpStatusCode.BadRequest + "", ex.Message, cashbook));
            }
            return Ok(inserted);
        }

        [HttpGet]
        public async Task<CashBookModel> GetAll([FromQuery] PageParameters pageParameters)
        {
            return await _icashBookApplication.GetAllCashBook(pageParameters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CashBook>> GetById(Guid id)
        {
            var cashBook = await _icashBookApplication.GetCashBookById(id);
            if (cashBook == null)
            {
                return NoContent();
            }

            return Ok(cashBook);
        }

        [HttpGet("ByOrigId")]
        public async Task<ActionResult<CashBook>> GetByOrigintId(Guid OriginId)
        {
            var cashbook = await _icashBookApplication.GetCashBookOriginId(OriginId);
            if (cashbook == null) { return NoContent(); }
            return Ok(cashbook);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CashBookDTO cashbook)
        {
            CashBook cashBookUpdated = null;
            try
            {
                cashBookUpdated = await _icashBookApplication.PutCashBook(cashbook);
            }
            catch (Exception ex)
            {
                return BadRequest(new CashBookErrorMessage("" + (int)HttpStatusCode.BadRequest + "", ex.Message, cashbook));
            }
            return Ok(cashBookUpdated);
        }
    }
}