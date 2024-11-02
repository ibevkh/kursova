using AutoMapper;
using courseWork.Dto;
using courseWork.Entity;

namespace courseWork.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            // Мапінг для Jewellery і JewelleryDto
            CreateMap<JewelleryDto, Jewellery>().ReverseMap();

            // Мапінг для OrderJewelleryItemDto і Jewellery (прив'язка до структури всередині замовлення)
            CreateMap<OrderJewelleryItemDto, Jewellery>().ReverseMap();

            // Мапінг для Customer і CustomerDto
            CreateMap<CustomerDto, Customer>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ReverseMap();

            // мапінг для Order і OrderDto
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Jewelleries, opt => opt.MapFrom(src => src.OrderJewelleries))
                .ReverseMap();

            // Мапінг для OrderJewelleries і OrderJewelleryItemDto
            CreateMap<OrderJewelleries, OrderJewelleryItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.JewelleryId))
                .ReverseMap();
        }
    }
}