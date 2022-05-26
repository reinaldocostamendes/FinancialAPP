using CashBookDomain.DTO;
using Infrastructure.Service.Interface;

namespace CashBook_Api.Contracts
{
    public class CashBookErrorMessage : ErrorMessage<CashBookDTO>
    {
        public CashBookErrorMessage(string code, string message, CashBookDTO contract) : base(code, message, contract)
        {
        }
    }
}