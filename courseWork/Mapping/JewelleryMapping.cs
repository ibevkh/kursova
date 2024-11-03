using AutoMapper;
using courseWork.Dto;
using courseWork.Entity;

namespace courseWork.Mapping
{
    public class Mapping : Profile {
        public Mapping()
        {
            // Мапінг для JewelleryDto і Jewellery
            CreateMap<JewelleryDto, Jewellery>().ReverseMap();

            // Мапінг для OrderJewelleryItemDto і Jewellery
            CreateMap<OrderJewelleryItemDto, OrderJewelleries>()
                .ForMember(dest => dest.Jewellery, opt => opt.Ignore()) // Ігноруємо Jewellery, оскільки ми заповнимо його пізніше
                .ForMember(dest => dest.JewelleryId, opt => opt.MapFrom(src => src.Id)); // Призначаємо JewelleryId

            // Мапінг для Customer і CustomerDto
            CreateMap<CustomerDto, Customer>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ReverseMap();

            // Мапінг для Order і OrderDto
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Jewelleries, opt => opt.MapFrom(src => src.OrderJewelleries))
                .ReverseMap();

            // Мапінг для OrderJewelleries і OrderJewelleryItemDto
            CreateMap<OrderJewelleries, OrderJewelleryItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.JewelleryId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Jewellery.Name)) // Заповнюємо Name
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Jewellery.Type)) // Заповнюємо Type
                .ForMember(dest => dest.Material, opt => opt.MapFrom(src => src.Jewellery.Material)) // Заповнюємо Material
                .ForMember(dest => dest.Gemstones, opt => opt.MapFrom(src => src.Jewellery.Gemstones)) // Заповнюємо Gemstones
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Jewellery.Size)) // Заповнюємо Size
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Jewellery.Price)); // Заповнюємо Price
        }
    }
}
