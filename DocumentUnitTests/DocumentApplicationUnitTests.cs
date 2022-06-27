using AutoMapper;
using Document_Application.Application.Interface;
using Document_Application.Service.Interface;
using DocumentDomain.DTO;
using Infrastructure.Entity;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DocumentUnitTests
{
    public class DocumentApplicationUnitTests
    {
        private readonly AutoMocker Mocker;

        public DocumentApplicationUnitTests()
        {
            Mocker = new AutoMocker();
        }

        [Fact(DisplayName = "AddDocument Test")]
        public async Task AddDocument()
        {
            var documentDTO = DocumentFaker.GenerateDocDTO();

            var docReqService = Mocker.GetMock<IDocumentApplication>();
            docReqService.Setup(X => X.AddDocument(documentDTO));

            var documentApplication = Mocker.Get<IDocumentApplication>();

            await documentApplication.AddDocument(documentDTO);

            docReqService.Verify(x => x.AddDocument(It.IsAny<DocumentDTO>()), Times.Once());
        }

        [Fact(DisplayName = "GetAllDocument Test")]
        public async Task GetAllBuyRequest()
        {
            var docReqService = Mocker.GetMock<IDocumentService>();
            PageParameters pg = new PageParameters();
            docReqService.Setup(x => x.GetAllDocuments(pg));

            var documentApplication = Mocker.Get<IDocumentService>();

            await documentApplication.GetAllDocuments(pg);

            docReqService.Verify(x => x.GetAllDocuments(pg), Times.Once());
        }

        [Fact(DisplayName = "GetByIdDocument Test")]
        public async Task GetByIdBuyRequest()
        {
            var docReq = DocumentFaker.GenerateDoc();

            var buyReqService = Mocker.GetMock<IDocumentApplication>();
            buyReqService.Setup(x => x.GetById(docReq.Id));

            var documentApplication = Mocker.Get<IDocumentApplication>();

            await documentApplication.GetById(docReq.Id);

            buyReqService.Verify(x => x.GetById(docReq.Id), Times.Once());
        }

        [Fact(DisplayName = "UpdateDocument Test")]
        public async Task UpdateDocument()
        {
            var docReq = DocumentFaker.GenerateDoc();
            var documentDTO = DocumentFaker.GenerateDocDTO();

            var docReqService = Mocker.GetMock<IDocumentApplication>();

            docReqService.Setup(x => x.UpdateDocument(documentDTO));

            var documentApplication = Mocker.Get<IDocumentApplication>();

            await documentApplication.UpdateDocument((documentDTO));

            docReqService.Verify(x => x.UpdateDocument(It.IsAny<DocumentDTO>()), Times.Once());
        }

        [Fact(DisplayName = "DeleteDocument Test")]
        public async Task DeleteDocument()
        {
            var document = DocumentFaker.GenerateDoc();

            var docReqService = Mocker.GetMock<IDocumentApplication>();
            docReqService.Setup(x => x.DeleteDocument(document.Id));

            var documentApplication = Mocker.Get<IDocumentApplication>();

            await documentApplication.DeleteDocument(document.Id);

            docReqService.Verify(x => x.DeleteDocument(document.Id), Times.Once());
        }
    }
}