using AutoMapper;
using courseWork.Dto;
using courseWork.Entity;

namespace courseWork.Mapping
{
    public class Mapping : Profile 
    {
        public Mapping()
        {
            CreateMap<JewelleryDto, Jewellery>().ReverseMap();
            CreateMap<OrderJewelleryItemDto, Jewellery>();

            CreateMap<CustomerDto, Customer>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
