using BuyRequest_Api.Data;
using BuyRequestData.Repository.Interface;
using Infrastructure.Entity;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BuyRequestData.Repository
{
    public class BuyRequestRepository : RepositoryBase<BuyRequest>, IBuyRequestRepository
    {
        private readonly BuyRequestContext _context;

        public BuyRequestRepository(BuyRequestContext context) : base(context)
        {
            _context = context;
            SetInclude(x => x.Include(p => p.Products));
        }

        public async Task DeleteBuyRequest(Guid id)
        {
            var br = await GetById(id);
            if (br != null)
            {
                await Delete(br);
            }
        }

        public async Task<BuyRequest> GetBuyRequestsByCode(long code)
        {
            return await _context.BuyRequests.Include(p => p.Products).Where(b => b.Code == code).FirstOrDefaultAsync();
        }

        public async Task<BuyRequest> GetBuyRequestByClient(Guid id)
        {
            return await _context.BuyRequests.Include(p => p.Products).Where(b => b.Client == id).FirstOrDefaultAsync();
        }

        public async Task<BuyRequest> GetBuyRequestById(Guid id)
        {
            return await _context.BuyRequests.Include(p => p.Products).Where(b => b.Id == id).FirstOrDefaultAsync();
        }
    }
}