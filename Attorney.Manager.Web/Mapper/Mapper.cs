using Attorney.Manager.Domain.Addresses;
using Attorney.Manager.Domain.Registration;
using Attorney.Manager.Web.Models.Addresses;
using Attorney.Manager.Web.Models.Registration;
using AutoMapper;
using System.Collections.Generic;

namespace Attorney.Manager.Web.Mapper
{
    internal static class RegistrationMapper
    {
        private static  MapperConfiguration _mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Domain.Registration.Attorney, AttorneyViewModel>()
            .ForMember(dst => dst.CommercialAdress, opt => opt.MapFrom(src => src.CommercialAdress))
            .ForPath(dst => dst.CommercialAdress.StreetName, opt => opt.MapFrom(src => src.CommercialAdress.StreetName))
            .ForPath(dst => dst.CommercialAdress.State, opt => opt.MapFrom(src => src.CommercialAdress.State))
            .ForPath(dst => dst.CommercialAdress.PostalCode, opt => opt.MapFrom(src => src.CommercialAdress.PostalCode))
            .ForPath(dst => dst.CommercialAdress.City, opt => opt.MapFrom(src => src.CommercialAdress.City))
            .ForPath(dst => dst.CommercialAdress.Id, opt => opt.MapFrom(src => src.CommercialAdress.Id))
            .ForPath(dst => dst.CommercialAdress.Country, opt => opt.MapFrom(src => src.CommercialAdress.Country))
            .ForPath(dst => dst.CommercialAdress, opt => opt.MapFrom(src => src.CommercialAdress))
            .ForMember(dst => dst.Seniority, opt => opt.MapFrom(src => src.Seniority))
            .ReverseMap();

            cfg.CreateMap<Seniority, SeniorityViewModel>().ReverseMap();
            cfg.CreateMap<CommercialAdress, CommercialAdressViewModel>().ReverseMap();
        });

        public static IList<T2> AttorneyMapper<T1, T2>(IList<T1> obj) 
            => _mapperConfiguration.CreateMapper().Map<IList<T2>>(obj); 
        
        public static T2 AttorneyMapper<T1, T2>(T1 obj) 
            => _mapperConfiguration.CreateMapper().Map<T2>(obj); 
        
    }
}