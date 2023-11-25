
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
            CreateMap<User, UserForListDto>();
            //CreateMap<RequestForListDto, Request>();
            CreateMap<Request, RequestForListDto>()
                .ForMember(dest => dest.OrderTotal, opt =>
                {
                    opt.MapFrom(d => d.OrderTotal());
                });
            CreateMap<RequestItem, RequestItemForListDto>();
            CreateMap<RequestItemForCreateDto, RequestItem>();
            CreateMap<Request, RequestForDetailedDto>();
            CreateMap<RequestItem, RequestItemForDetailedDto>();
        }
    }
}
