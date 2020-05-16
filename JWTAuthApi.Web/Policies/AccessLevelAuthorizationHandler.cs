using System;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthApi.Core.Entities;
using Microsoft.AspNetCore.Authorization;

namespace JWTAuthApi.Web.Policies
{
    public class AccessLevelAuthorizationHandler : AuthorizationHandler<AccessLevelRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            AccessLevelRequirement requirement)
        {
            var user = context.User;
            var claim = context.User.Claims.FirstOrDefault(c => c.Type == PoliciesEntity.AccessLevelClaimType);
            if (claim != null)
            {
                var accessLevel = int.Parse(claim.Value);
                if (accessLevel >= requirement.MinimumAccessLevel)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}