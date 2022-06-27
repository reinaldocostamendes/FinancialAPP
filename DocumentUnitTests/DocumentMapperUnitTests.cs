using AutoMapper;
using Document_Application.Application.Interface;
using Document_Application.Service.Interface;
using DocumentDomain.DTO;
using DocumentDomain.Entity;
using DocumentDomain.Mapping;
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
    public class DocumentMapperUnitTests
    {
        private readonly AutoMocker Mocker;
        private static IMapper _mapper;

        public DocumentMapperUnitTests()
        {
            Mocker = new AutoMocker();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact(DisplayName = "MapDocument Test")]
        public void MapDocument()
        {
            var documentDTO = DocumentFaker.GenerateDocDTO();
            Document document = _mapper.Map<Document>(documentDTO);

            Assert.True(documentDTO.Payed == document.Payed &&
                documentDTO.Date == document.Date &&
                documentDTO.PaymentDate == document.PaymentDate &&
                documentDTO.DocumentType == document.DocumentType &&
                documentDTO.Total == document.Total &&
                documentDTO.Number == document.Number);
        }
    }
}