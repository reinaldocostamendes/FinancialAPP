using BuyRequestDomain.Entity;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyRequest_Application.Service.Interface
{
    public interface IBuyRequestService
    {
        Task AddBuyRequest(BuyRequest order);

        Task<List<BuyRequest>> GetAllBuyRequests(PageParameters pageParameters);

        Task<BuyRequest> GetBuyRequestsByCode(long code);

        Task<BuyRequest> GetBuyRequestByClient(Guid id);

        Task<BuyRequest> GetBuyRequestById(Guid id);

        Task UpdateBuyRequest(BuyRequest order);

        Task DeleteBuyRequest(Guid id);
    }
}