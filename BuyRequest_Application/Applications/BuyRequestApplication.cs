using AutoMapper;
using BuyRequest_Application.Interface;
using BuyRequest_Application.Service.Interface;
using BuyRequestDomain.DTO;
using BuyRequestDomain.ViewModels;
using CashBook_API_Client.Interface;
using CashBookDomain.DTO;
using Infrastructure.Entity;
using Infrastructure.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BuyRequest_Application.Applications
{
    public class BuyRequestApplication : IBuyRequestApplication
    {
        private readonly IBuyRequestService _buyRequestService;
        private readonly IProductApplication productApplication;
        private readonly IMapper _imapper;
        private readonly ICashBookClient cashBookClient;

        public BuyRequestApplication(IBuyRequestService buyRequestService,
            IProductApplication productApplication, IMapper imapper, ICashBookClient cashBookClient)
        {
            _buyRequestService = buyRequestService;
            _imapper = imapper;
            this.cashBookClient = cashBookClient;
            this.productApplication = productApplication;
        }

        public async Task<BuyRequest> AddBuyRequest(BuyRequestDTO buyRequestDTO)
        {
            var buy_request = _imapper.Map<BuyRequest>(buyRequestDTO);
            buy_request.Id = Guid.NewGuid();

            buy_request.Status = BuyRequestStatus.RECEIVED;
            if (!buy_request.IsValid())
            {
                var message = buy_request.
                     ValidationResult.Errors.
                     ConvertAll(x => x.ErrorMessage.ToString()).ToList();

                throw new Exception(ErrorList(message));
            }
            else
            {
                await _buyRequestService.AddBuyRequest(buy_request);
            }
            return buy_request;
        }

        public async Task<bool> DeleteBuyRequest(Guid id)
        {
            var buy_request_to_delete = await _buyRequestService.GetBuyRequestById(id);

            if (buy_request_to_delete == null) { return true; }
            if (buy_request_to_delete.Status == BuyRequestStatus.FINISHED)
            {
                var cashBookDTO = new CashBookDTO()
                {
                    Origin = CashBookOrigin.PURCHASEORDER,
                    OriginId = buy_request_to_delete.Id,
                    Description = "Purshase order Nº " + buy_request_to_delete.Code,
                    Value = buy_request_to_delete.TotalValue,
                    Type = CashBookType.REVERSAL
                };
                var response = await cashBookClient.PostCashBook(cashBookDTO);
                if (response == false)
                {
                    throw new Exception("Error to put cashbook! " + response.ToString());
                }
                else
                {
                    buy_request_to_delete.Status = BuyRequestStatus.FINISHED;
                    await _buyRequestService.DeleteBuyRequest(id);
                }
            }
            else
            {
                await _buyRequestService.DeleteBuyRequest(id);
            }
            return true;
        }

        public async Task<List<BuyRequest>> GetAllBuyRequests(PageParameters pageParameters)
        {
            return await _buyRequestService.GetAllBuyRequests(pageParameters);
        }

        public async Task<BuyRequest> GetBuyRequestsByCode(long code)
        {
            return await _buyRequestService.GetBuyRequestsByCode(code);
        }

        public async Task<BuyRequest> GetBuyRequestsByClient(Guid id)
        {
            return await _buyRequestService.GetBuyRequestByClient(id);
        }

        public async Task<BuyRequest> UpdateBuyRequest(BuyRequestDTO buyRequestDTO)

        {
            var buy_request_to_update = _imapper.Map<BuyRequest>(buyRequestDTO);
            if (buy_request_to_update == null)
            {
                throw new Exception("This BuyRequest not exists!");
            }
            if (buy_request_to_update.Status == BuyRequestStatus.FINISHED)
            {
                throw new Exception("This BuyRequest is concluded!");
            }

            if (!buy_request_to_update.IsValid())
            {
                var message = buy_request_to_update.
                    ValidationResult.Errors.
                    ConvertAll(x => x.ErrorMessage.ToString()).ToList();

                throw new Exception(ErrorList(message));
            }
            await _buyRequestService.UpdateBuyRequest(buy_request_to_update);
            var productsIds = buy_request_to_update
                .Products.Select(s => s.Id).ToList();

            var result = productApplication.GetAllProducts().Result.Where(p => p.BuyRequestId == buyRequestDTO.Id);
            foreach (var product in result.Where(w => !productsIds.Contains(w.Id)).ToList())
            {
                await productApplication.DeleteProduct(product.Id);
            }

            var cashBookDTO = new CashBookDTO()
            {
                Origin = CashBookOrigin.PURCHASEORDER,
                OriginId = buy_request_to_update.Id,
                Description = "Updated Purshase order Nº " + buy_request_to_update.Code,
                Value = buyRequestDTO.TotalValue - buy_request_to_update.TotalValue,
                Type = ((buyRequestDTO.TotalValue - buy_request_to_update.TotalValue) > 0)
                ? CashBookType.PAYMENT : CashBookType.RECEIVEMENT
            };

            var response = await cashBookClient.PostCashBook(cashBookDTO);
            if (response == false)
            {
                throw new Exception("Error to post cashbook! " + response.ToString());
            }

            return buy_request_to_update;
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

        public async Task<BuyRequest> UpdateBuyRequestStatus(Guid id, BuyRequestStatus status)
        {
            var buy_request_to_update = await _buyRequestService.GetBuyRequestById(id);

            if (buy_request_to_update == null)
            {
                throw new Exception("Order Not Found!");
            }
            var products = productApplication.GetAllProductsByBuyRequestId(id);

            var p = products.Result.Where(p => p.ProductCategory == ProductCategory.FISICAL);
            if (p.Count() > 0 && buy_request_to_update.Status == BuyRequestStatus.WAITING_DOWNLOAD)
            {
                throw new Exception("Not allowed to change fisical product to waiting download!");
            }
            var p2 = products.Result.Where(p => p.ProductCategory == ProductCategory.DIGITAL);
            if (p2.Count() > 0 && buy_request_to_update.Status == BuyRequestStatus.WAITING_DELIVERY)
            {
                throw new Exception("Not allowed to change Digital product to waiting Delivery!");
            }

            if (buy_request_to_update.Status == BuyRequestStatus.FINISHED)
            {
                throw new Exception("Not allowed to change finished status!");
            }

            if (status == BuyRequestStatus.FINISHED)
            {
                var cashBookDTO = new CashBookDTO()
                {
                    Origin = CashBookOrigin.PURCHASEORDER,
                    OriginId = buy_request_to_update.Id,
                    Description = "Purshase order Nº " + buy_request_to_update.Code,
                    Value = -buy_request_to_update.TotalValue,
                    Type = CashBookType.PAYMENT
                };
                var response = await cashBookClient.PostCashBook(cashBookDTO);
                if (response == false)
                {
                    throw new Exception("Error to put cashbook! " + response.ToString());
                }
                else
                {
                    buy_request_to_update.Status = BuyRequestStatus.FINISHED;
                    await _buyRequestService.UpdateBuyRequest(buy_request_to_update);
                }
            }
            else
            {
                buy_request_to_update.Status = status;
                await _buyRequestService.UpdateBuyRequest(buy_request_to_update);
            }
            return buy_request_to_update;
        }
    }
}