using AutoMapper;
using CashBook_API_Client.Interface;
using CashBookDomain.DTO;
using CashBookDomain.Entity.Enums;
using Document_Application.Application.Interface;
using Document_Application.Service.Interface;
using DocumentDomain.DTO;
using DocumentDomain.Entity;
using DocumentDomain.ViewModels;
using Infrastructure.Entity;
using Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Document_Application.Application
{
    public class DocumentApplication : IDocumentApplication
    {
        private readonly IDocumentService _idocumentService;
        private readonly IMapper _imapper;
        private readonly IMessageProducer _messagePublisher;

        public DocumentApplication(IDocumentService idocumentService, IMapper imapper, IMessageProducer messageProducer)
        {
            _idocumentService = idocumentService;
            _imapper = imapper;
            _messagePublisher = messageProducer;
        }

        public async Task<Document> AddDocument(DocumentDTO documentDTO)
        {
            var document = _imapper.Map<Document>(documentDTO);
            if (!document.IsValid())
            {
                var message = document.
                    ValidationResult.Errors.
                    ConvertAll(x => x.ErrorMessage.ToString()).ToList();

                throw new Exception(ErrorList(message));
            }
            else
            {
                await _idocumentService.AddDocument(document);
                if (document.Payed == true)
                {
                    var cashBookDto = new CashBookDTO()
                    {
                        Origin = CashBookOrigin.PURCHASEORDER,
                        OriginId = document.Id,
                        Description = "Document:" + document.Number,
                        Value = document.Total,
                        Type = CashBookType.RECEIVEMENT
                    };

                    _messagePublisher.SendMessage(cashBookDto);
                }
            }
            return document;
        }

        private String ErrorList(List<string> message)
        {
            var string_errors = "[ ";
            foreach (var error in message)
            {
                string_errors += " - " + error.ToString();
            }
            return string_errors + " ]";
        }

        public async Task<bool> DeleteDocument(Guid id)
        {
            var document = await _idocumentService.GetById(id);
            if (document == null) { return true; }
            else
            {
                await _idocumentService.DeleteDocument(id);
                var cashBookDTO = new CashBookDTO()
                {
                    Origin = CashBookOrigin.PURCHASEORDER,
                    OriginId = document.Id,
                    Description = "Document:" + document.Number,
                    Value = document.Total,
                    Type = CashBookType.REVERSAL
                };

                _messagePublisher.SendMessage(cashBookDTO);
            }
            return true;
        }

        public async Task<List<Document>> GetAllDocuments(PageParameters pageParameters)
        {
            return await _idocumentService.GetAllDocuments(pageParameters);
        }

        public async Task<Document> GetById(Guid id)
        {
            return await _idocumentService.GetById(id);
        }

        public async Task<Document> UpdateDocument(DocumentDTO document)
        {
            var existedDocument = _imapper.Map<Document>(document);

            var cashBookDTO = new CashBookDTO()
            {
                Origin = CashBookOrigin.PURCHASEORDER,
                OriginId = existedDocument.Id,
                Description = "Document:" + document.Number
            };

            if (document.Payed == true)
            {
                document.PaymentDate = DateTime.Now;
                cashBookDTO.Value = document.Total - existedDocument.Total;
                cashBookDTO.Type = ((document.Total - existedDocument.Total) > 0) ? CashBookType.RECEIVEMENT : CashBookType.PAYMENT;
            }
            else
            {
                cashBookDTO.Value = document.Total - existedDocument.Total;
                cashBookDTO.Type = ((document.Total - existedDocument.Total) > 0) ? CashBookType.RECEIVEMENT : CashBookType.PAYMENT;
            }

            if (!existedDocument.IsValid())
            {
                var message = "[ ";
                foreach (var error in existedDocument.ValidationResult.Errors)
                {
                    message += error.ToString() + ", ";
                }
                message += " ]";
                throw new Exception(message);
            }
            else
            {
                _messagePublisher.SendMessage(cashBookDTO);

                await _idocumentService.UpdateDocument(existedDocument);
            }
            return existedDocument;
        }

        public async Task<Document> UpdatePayementDocument(UpdatePaymentViewModel pvm)
        {
            var document = await _idocumentService.GetById(pvm.Id);
            document.Payed = pvm.Payed;
            document.PaymentDate = DateTime.Now;
            var cashBookDTO = new CashBookDTO()
            {
                Origin = CashBookOrigin.PURCHASEORDER,
                OriginId = document.Id,
                Description = "Document:" + document.Number,
                Value = (pvm.Payed == true) ? -document.Total : document.Total,
                Type = (pvm.Payed == true) ? CashBookType.PAYMENT : CashBookType.RECEIVEMENT
            };
            _messagePublisher.SendMessage(cashBookDTO);
            await _idocumentService.UpdatePayementDocument(document);
            return document;
        }
    }
}