using Infrastructure.Entity;
using Infrastructure.Service.Interface;

namespace BuyRequest_Api.Contracts
{
    public class BuyRequestErrorMessage : ErrorMessage<BuyRequest>
    {
        public BuyRequestErrorMessage(string code, string message, BuyRequest contract) : base(code, message, contract)
        {
        }
    }
}