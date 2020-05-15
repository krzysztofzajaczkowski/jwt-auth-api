using System.ComponentModel.DataAnnotations;

namespace JWTAuthApi.Web.Dtos.UserDtos
{
    public class UserRegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}