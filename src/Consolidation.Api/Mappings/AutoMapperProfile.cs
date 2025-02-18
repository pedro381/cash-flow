using AutoMapper;
using Consolidation.Api.DTOs;

namespace Consolidation.Api.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Entities.Consolidation, ConsolidationDto>().ReverseMap();
        }
    }
}
