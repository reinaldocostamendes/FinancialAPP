using AutoMapper;
using CashBookDomain.DTO;
using CashBookDomain.Entity;
using Infrastructure.Entity;

namespace CashBookDomain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CashBook, CashBookDTO>().ReverseMap();
        }
    }
}