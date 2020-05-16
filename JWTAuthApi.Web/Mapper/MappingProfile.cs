using AutoMapper;
using JWTAuthApi.Core.Models;
using JWTAuthApi.Web.Dtos.UserDtos;
using JWTAuthApi.Web.Dtos.UserPolicyDtos;
using JWTAuthApi.Web.Dtos.UserRoleDtos;

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

            CreateMap<UserPolicy, UserPolicyDto>();
            CreateMap<UserPolicyDto, UserPolicy>();
        }
    }
}