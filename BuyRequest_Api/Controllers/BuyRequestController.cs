using AutoMapper;
using BuyRequest_Api.Contracts;
using BuyRequest_Application.Interface;
using BuyRequestDomain.DTO;
using BuyRequestDomain.ViewModels;
using Infrastructure.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BuyRequest_Api.Controllers
{
    [Route("api/BuyRequests")]
    [ApiController]
    public class BuyRequestController : ControllerBase
    {
        private readonly IBuyRequestApplication _irequestApplication;
        private readonly IProductApplication _iproductApplication;
        private readonly IMapper _imapper;

        public BuyRequestController(IBuyRequestApplication irequestApplication, IProductApplication iproductApplication, IMapper imapper)
        {
            _irequestApplication = irequestApplication;
            _iproductApplication = iproductApplication;
            _imapper = imapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BuyRequestDTO order)
        {
            BuyRequest inserted_result = null;
            try
            {
                inserted_result = await _irequestApplication.AddBuyRequest(order);
            }
            catch (Exception ex)
            {
                return BadRequest(new BuyRequestErrorMessage("" + (int)HttpStatusCode.BadRequest + "", ex.Message, _imapper.Map<BuyRequest>(order)));
            }
            return Ok(inserted_result);
        }

        [HttpGet]
        public async Task<List<BuyRequest>> GetAll([FromQuery] PageParameters pageParameters)
        {
            return await _irequestApplication.GetAllBuyRequests(pageParameters); ;
        }

        [HttpGet("ClientId")]
        public async Task<ActionResult<BuyRequest>> GetByClient(Guid id)
        {
            var existed_buy_reqeust = await _irequestApplication.GetBuyRequestsByClient(id);
            if (existed_buy_reqeust == null)
            {
                return NoContent();
            }
            return existed_buy_reqeust;
        }

        [HttpPut]
        public async Task<IActionResult> Put(BuyRequestDTO order)
        {
            BuyRequest updatedBuyRequest = null;
            try
            {
                updatedBuyRequest = await _irequestApplication.UpdateBuyRequest(order);
            }
            catch (Exception ex)
            {
                return BadRequest(new BuyRequestErrorMessage("" + (int)HttpStatusCode.BadRequest + "", ex.Message, _imapper.Map<BuyRequest>(order)));
            }
            return Ok(updatedBuyRequest);
        }

        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] BuyRequestStatusModel buyRequestStatusViewModel)
        {
            BuyRequest buyRequestChanged = null;
            try
            {
                buyRequestChanged = await _irequestApplication.UpdateBuyRequestStatus(buyRequestStatusViewModel.Id, buyRequestStatusViewModel.BuyRequestStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(new BuyRequestErrorMessage("" + (int)HttpStatusCode.BadRequest + "", ex.Message, _imapper.Map<BuyRequest>(buyRequestStatusViewModel)));
            }
            return Ok(buyRequestChanged);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _irequestApplication.DeleteBuyRequest(id));
        }
    }
}