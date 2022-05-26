using BuyRequestDomain.DTO;
using BuyRequestDomain.ViewModels;
using Infrastructure.Entity;
using Infrastructure.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyRequest_Application.Interface
{
    public interface IBuyRequestApplication
    {
        Task<BuyRequest> AddBuyRequest(BuyRequestDTO order);

        Task<List<BuyRequest>> GetAllBuyRequests(PageParameters pageParameters);

        Task<BuyRequest> GetBuyRequestsByCode(long code);

        Task<BuyRequest> GetBuyRequestsByClient(Guid id);

        Task<BuyRequest> UpdateBuyRequest(BuyRequestDTO order);

        Task<BuyRequest> UpdateBuyRequestStatus(Guid id, BuyRequestStatus buyrequestStatus);

        Task<bool> DeleteBuyRequest(Guid id);
    }
}