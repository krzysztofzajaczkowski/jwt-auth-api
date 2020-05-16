using System.Collections.Generic;
using JWTAuthApi.Web.Dtos.UserPolicyDtos;
using JWTAuthApi.Web.Dtos.UserRoleDtos;

namespace JWTAuthApi.Web.Dtos.UserDtos
{
    public class UserPreviewDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public List<UserRoleDto> Roles { get; set; }
        public List<UserPolicyDto> Policies { get; set; }

    }
}