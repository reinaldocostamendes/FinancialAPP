using BuyRequestDomain.Entity;
using Infrastructure.Entity;
using Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyRequestData.Repository.Interface
{
    public interface IBuyRequestRepository : IRepositoryBase<BuyRequest>
    {
        Task<BuyRequest> GetBuyRequestsByCode(long code);

        Task<BuyRequest> GetBuyRequestByClient(Guid id);

        Task<BuyRequest> GetBuyRequestById(Guid id);

        Task DeleteBuyRequest(Guid id);
    }
}