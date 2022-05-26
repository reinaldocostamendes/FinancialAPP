using DocumentDomain.DTO;
using Infrastructure.Service.Interface;

namespace Document_Api.Contracts
{
    public class DocumentErrorMessage : ErrorMessage<DocumentDTO>
    {
        public DocumentErrorMessage(string code, string message, DocumentDTO contract) : base(code, message, contract)
        {
        }
    }
}