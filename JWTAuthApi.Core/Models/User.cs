using System.Collections.Generic;

namespace JWTAuthApi.Core.Models
{
    public class User
    {
        public User()
        {
            Roles = new List<UserRole>();
            Policies = new List<UserPolicy>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public List<UserRole> Roles { get; set; }
        public List<UserPolicy> Policies { get; set; }
    }
}