using AutoMapper;
using Document_Api.Controllers;
using Document_Application.Application.Interface;
using Document_Application.Repository.Interface;
using Document_Application.Service;
using Document_Application.Service.Interface;
using DocumentDomain.DTO;
using Infrastructure.Entity;
using Infrastructure.Entity.Enums;
using Moq;
using Moq.AutoMock;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tests.AutoFakers;
using Xunit;

namespace Tests
{
    public class DocumentControllerTest
    {
        private readonly AutoMocker Mocker;

        public DocumentControllerTest()
        {
            Mocker = new AutoMocker();
        }

        [Fact(DisplayName = "PostDocument Test")]
        public async Task Pos()
        {
            var documentDTO = DocumentFaker.GenerateDocDTO();

            var docReqService = Mocker.GetMock<IDocumentApplication>();
            docReqService.Setup(X => X.AddDocument(documentDTO));

            var docReqController = Mocker.CreateInstance<DocumentController>();

            await docReqController.Post(documentDTO);

            docReqService.Verify(x => x.AddDocument(It.IsAny<DocumentDTO>()), Times.Once());
        }

        [Fact(DisplayName = "GetAllDocument Test")]
        public async Task GetAllBuyRequest()
        {
            var docReqService = Mocker.GetMock<IDocumentApplication>();
            PageParameters pg = new PageParameters();
            docReqService.Setup(x => x.GetAllDocuments(pg));

            var docReqController = Mocker.CreateInstance<DocumentController>();

            await docReqController.GetAll(pg);

            docReqService.Verify(x => x.GetAllDocuments(pg), Times.Once());
        }

        [Fact(DisplayName = "GetByIdDocument Test")]
        public async Task GetByIdBuyRequest()
        {
            var docReq = DocumentFaker.GenerateDoc();

            var buyReqService = Mocker.GetMock<IDocumentApplication>();
            buyReqService.Setup(x => x.GetById(docReq.Id));

            var buyReqController = Mocker.CreateInstance<DocumentController>();

            await buyReqController.GetById(docReq.Id);

            buyReqService.Verify(x => x.GetById(docReq.Id), Times.Once());
        }

        [Fact(DisplayName = "UpdateDocument Test")]
        public async Task UpdateDocument()
        {
            var docReq = DocumentFaker.GenerateDoc();
            var documentDTO = DocumentFaker.GenerateDocDTO();

            var docReqService = Mocker.GetMock<IDocumentApplication>();

            docReqService.Setup(x => x.UpdateDocument(documentDTO));

            var documentController = Mocker.CreateInstance<DocumentController>();

            await documentController.Put((documentDTO));

            docReqService.Verify(x => x.UpdateDocument(It.IsAny<DocumentDTO>()), Times.Once());
        }

        [Fact(DisplayName = "DeleteDocument Test")]
        public async Task DeleteDocument()
        {
            var document = DocumentFaker.GenerateDoc();

            var docReqService = Mocker.GetMock<IDocumentApplication>();
            docReqService.Setup(x => x.DeleteDocument(document.Id));

            var docReqController = Mocker.CreateInstance<DocumentController>();

            await docReqController.Delete(document.Id);

            docReqService.Verify(x => x.DeleteDocument(document.Id), Times.Once());
        }
    }
}