using Document_Application.Context;
using Document_Application.Repository.Interface;
using Infrastructure.Entity;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Document_Application.Repository
{
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository

    {
        public DocumentRepository(DocumentContext context) : base(context)
        {
        }

        public async Task AddDocument(Document document)
        {
            await Post(document);
        }

        public async Task DeleteDocument(Guid id)
        {
            var document = await base.GetById(id);
            await Delete(document);
        }

        public async Task<List<Document>> GetAllDocuments(PageParameters pageParameters)
        {
            return await GetAll(pageParameters);
        }

        public async Task UpdateDocument(Document document)
        {
            await Put(document);
        }

        public async Task UpdatePayementDocument(Document document)
        {
            document.Payed = true;
            await base.Put(document);
        }
    }
}