using BuyRequest_Application.Service.Interface;
using BuyRequestData.Repository.Interface;
using Infrastructure.Entity;
using Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyRequest_Application.Service
{
    public class BuyRequestService :  IBuyRequestService
    {
        private readonly IBuyRequestRepository _ibuyRequestrepository;

        public BuyRequestService(IBuyRequestRepository ibuyRequestrepository)
        {
            _ibuyRequestrepository = ibuyRequestrepository;
        }

        public async Task AddBuyRequest(BuyRequest order)
        {
            await _ibuyRequestrepository.Post(order);
        }

        public async Task DeleteBuyRequest(Guid id)
        {
            await _ibuyRequestrepository.DeleteBuyRequest(id);
        }

        public async Task<List<BuyRequest>> GetAllBuyRequests(PageParameters pageParameters)
        {
            return await _ibuyRequestrepository.GetAll(pageParameters);
        }

        public async Task<BuyRequest> GetBuyRequestByClient(Guid id)
        {
            return await _ibuyRequestrepository.GetBuyRequestByClient(id);
        }

        public async Task<BuyRequest> GetBuyRequestById(Guid id)
        {
            return await _ibuyRequestrepository.GetBuyRequestById(id);
        }

        public async Task<BuyRequest> GetBuyRequestsByCode(long code)
        {
            return await _ibuyRequestrepository.GetBuyRequestsByCode(code);
        }

        public async Task UpdateBuyRequest(BuyRequest order)
        {
            await _ibuyRequestrepository.Put(order);
        }
    }
}