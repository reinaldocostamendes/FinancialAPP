using AutoMapper;
using DocumentDomain.DTO;
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