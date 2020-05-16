using System.Collections.Generic;

namespace JWTAuthApi.Web.Dtos.UserDtos
{
    public class UserPreviewDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public List<UserRoleDto> Roles { get; set; }

    }
}