
using System.Linq;
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
            CreateMap<Request, RequestForDetailedDto>();
            CreateMap<RequestForRegistereDto, Request>();
            CreateMap<FinancialAide, FinancialAideForDetailedDto>();
            CreateMap<FinancialAideForRegisterDto, FinancialAide>();
        }
    }
}
