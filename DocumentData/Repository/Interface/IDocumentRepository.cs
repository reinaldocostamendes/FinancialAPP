using DocumentDomain.Entity;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentData.Repository.Interface
{
    public interface IDocumentRepository
    {
        Task AddDocument(Document document);

        Task<Document> GetById(Guid id);

        Task DeleteDocument(Guid id);

        Task<List<Document>> GetAllDocuments(PageParameters pageParameters);

        Task UpdateDocument(Document document);

        Task UpdatePayementDocument(Document document);
    }
}