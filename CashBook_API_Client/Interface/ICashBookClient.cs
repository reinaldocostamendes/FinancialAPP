using CashBookDomain.DTO;
using System.Threading.Tasks;

namespace CashBook_API_Client.Interface
{
    public interface ICashBookClient
    {
        Task<bool> PostCashBook(CashBookDTO cashBookDto);
    }
}