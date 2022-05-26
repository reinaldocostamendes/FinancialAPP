using Document_Application.Repository.Interface;
using Document_Application.Service.Interface;
using Infrastructure.Entity;
using Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Document_Application.Service
{
    public class DocumentService : ServiceBase<Document>, IDocumentService
    {
        private readonly IDocumentRepository documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public async Task AddDocument(Document document)
        {
            await documentRepository.AddDocument(document);
        }

        public async Task DeleteDocument(Guid id)
        {
            await documentRepository.DeleteDocument(id);
        }

        public async Task<List<Document>> GetAllDocuments(PageParameters pageParameters)
        {
            return await documentRepository.GetAllDocuments(pageParameters);
        }

        public async Task<Document> GetById(Guid id)
        {
            return await documentRepository.GetById(id);
        }

        public async Task UpdateDocument(Document document)
        {
            await documentRepository.UpdateDocument(document);
        }

        public async Task UpdatePayementDocument(Document document)
        {
            await documentRepository.UpdatePayementDocument(document);
        }
    }
}