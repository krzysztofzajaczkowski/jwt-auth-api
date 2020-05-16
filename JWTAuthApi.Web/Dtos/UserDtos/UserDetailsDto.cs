using System.Collections.Generic;
using JWTAuthApi.Core.Models;

namespace JWTAuthApi.Web.Dtos.UserDtos
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public List<UserRoleDto> Roles { get; set; }

    }
}