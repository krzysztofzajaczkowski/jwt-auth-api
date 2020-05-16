using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;

namespace JWTAuthApi.Web.Policies
{
    public class AccessLevelRequirement : IAuthorizationRequirement
    {
        public int MinimumAccessLevel { get; set; }
        public AccessLevelRequirement(int minimumAccessLevel)
        {
            MinimumAccessLevel = minimumAccessLevel;
        }
    }
}