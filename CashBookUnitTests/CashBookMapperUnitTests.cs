using AutoMapper;
using CashBook_Api.Controllers;
using CashBook_Application.Application;
using CashBook_Application.Application.Interface;
using CashBookDomain.DTO;
using CashBookDomain.Entity;
using CashBookDomain.Mapping;
using Infrastructure.Entity;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CashBookUnitTests
{
    public class CashBookMapperUnitTests
    {
        private readonly AutoMocker Mocker;
        private static IMapper _mapper;

        public CashBookMapperUnitTests()
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

        [Fact(DisplayName = "MapCashBook Test")]
        public void AddCashBook()
        {
            var cashBookDTO = CashBooktFaker.GenerateBCashBookDTO();
            CashBook cashBook = _mapper.Map<CashBook>(cashBookDTO);
            Assert.True(cashBookDTO.Type == cashBook
                .Type && cashBookDTO.Value == cashBook
                .Value && cashBookDTO.Description == cashBook
                .Description && cashBookDTO.OriginId == cashBook.OriginId);
        }
    }
}