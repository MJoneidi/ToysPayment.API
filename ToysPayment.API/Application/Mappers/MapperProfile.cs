using AutoMapper;
using ToysPayment.API.Models.Dto;
using ToysPayment.API.Models.Entities;

namespace ToysPayment.API.Application.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PaymentRequest, CardInfo>()
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.CardNumber))
                .ForMember(dest => dest.Cvv, opt => opt.MapFrom(src => src.CardCvv))
                .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(src => src.CardExpiry));
        }
    }
}
