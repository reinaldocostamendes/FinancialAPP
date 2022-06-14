using DocumentDomain.DTO;
using DocumentDomain.Entity;
using DocumentDomain.ViewModels;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Document_Application.Application.Interface
{
    public interface IDocumentApplication
    {
        Task<Document> AddDocument(DocumentDTO document);

        Task<List<Document>> GetAllDocuments(PageParameters pageParameters);

        Task<Document> GetById(Guid id);

        Task<Document> UpdateDocument(DocumentDTO document);

        Task<Document> UpdatePayementDocument(UpdatePaymentViewModel pvm);

        Task<bool> DeleteDocument(Guid id);
    }
}