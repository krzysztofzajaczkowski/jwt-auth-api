using System.ComponentModel.DataAnnotations;

namespace JWTAuthApi.Web.Dtos.UserDtos
{
    public class UserLoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}