using AutoMapper;
using DocumentDomain.DTO;
using DocumentDomain.Entity;
using Infrastructure.Entity;
using System;

namespace DocumentDomain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DocumentDTO, Document>().ForMember(op => op.Id, map => Guid.NewGuid()).ReverseMap(); ;
        }
    }
}