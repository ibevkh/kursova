using AutoMapper;
using courseWork.Dto;
using courseWork.Entity;

namespace courseWork.Mapping
{
    public class Mapping : Profile 
    {
        public Mapping()
        {
            CreateMap<JewelleryDto, JewelleryEntity>().ReverseMap();
            CreateMap<ClientDto, ClientEntity>().ReverseMap();
        }
    }
}
