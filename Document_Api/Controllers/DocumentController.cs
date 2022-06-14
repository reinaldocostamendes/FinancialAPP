using AutoMapper;
using Document_Api.Contracts;
using Document_Application.Application.Interface;
using DocumentDomain.DTO;
using DocumentDomain.Entity;
using DocumentDomain.ViewModels;
using Infrastructure.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Document_Api.Controllers
{
    [Route("api/Documents")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentApplication _idocumentApplication;
        private readonly IMapper _imapper;

        public DocumentController(IDocumentApplication idocumentApplication, IMapper imapper)
        {
            _idocumentApplication = idocumentApplication;
            _imapper = imapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DocumentDTO document)
        {
            Document insertedDocument = null;
            try
            {
                insertedDocument = await _idocumentApplication.AddDocument(document);
            }
            catch (Exception ex)
            {
                return BadRequest(new DocumentErrorMessage
                    ("" + (int)HttpStatusCode.BadRequest + "", ex.Message, null));
            }
            return Ok(insertedDocument);
        }

        [HttpGet]
        public async Task<List<Document>> GetAll([FromQuery] PageParameters pageParameters)
        {
            return await _idocumentApplication.GetAllDocuments(pageParameters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetById(Guid id)
        {
            var document = await _idocumentApplication.GetById(id);
            if (document == null)
            {
                return NoContent();
            }
            return Ok(document);
        }

        [HttpPut]
        public async Task<IActionResult> Put(DocumentDTO document)
        {
            try
            {
                await _idocumentApplication.UpdateDocument(document);
            }
            catch (Exception ex)
            {
                return BadRequest(new DocumentErrorMessage
                     ("" + (int)HttpStatusCode.BadRequest + "", ex.Message, null));
            }
            return Ok(document);
        }

        [HttpPut("SetPayment")]
        public async Task<IActionResult> PutPayment(UpdatePaymentViewModel document)
        {
            Document document_payed = null;
            try
            {
                document_payed = await _idocumentApplication.UpdatePayementDocument(document);
            }
            catch (Exception ex)
            {
                return BadRequest(new DocumentErrorMessage
                     ("" + (int)HttpStatusCode.BadRequest + "", ex.Message, null));
            }
            return Ok(document_payed);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _idocumentApplication.DeleteDocument(id));
        }
    }
}