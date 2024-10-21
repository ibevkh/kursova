using AutoMapper;
using courseWork.Dto;
using courseWork.Entity;

namespace courseWork.Mapping
{
    public class JewelleryMapping : Profile 
    {
        public JewelleryMapping()
        {
            CreateMap<JewelleryDto, JewelleryEntity>().ReverseMap();
        }
    }
}
