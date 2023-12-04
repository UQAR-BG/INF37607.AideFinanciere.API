using System;
using AutoMapper;
using EAISolutionFrontEnd.Core;
using EAISolutionFrontEnd.WebAPI.Dtos;

namespace EAISolutionFrontEnd.WebAPI
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            
            CreateMap<UserForRegisterDto, User>();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<User, UserForListDto>();
            CreateMap<UserForDetailedDto, User>();
            CreateMap<UserForUpdatedDto, User>();
            CreateMap<Request, RequestForDetailedDto>()
                .ForMember(dest => dest.DateStatus,
                    opt => opt.MapFrom(
                        src => DateOnly.FromDateTime(src.DateStatus)))
                .ForMember(dest => dest.StatusStartingDate,
                    opt => opt.MapFrom(
                        src => DateOnly.FromDateTime(src.StatusStartingDate)));
            CreateMap<RequestForRegistereDto, Request>();
            CreateMap<FinancialAide, FinancialAideForDetailedDto>();
            CreateMap<FinancialAideForRegisterDto, FinancialAide>();
        }
    }
}
