using AutoMapper;
using JWTAuthApi.Core.Models;
using JWTAuthApi.Web.Dtos.UserDtos;

namespace JWTAuthApi.Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDetailsDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserDetailsDto>();
            CreateMap<User, UserPreviewDto>();

            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleDto, UserRole>();
        }
    }
}